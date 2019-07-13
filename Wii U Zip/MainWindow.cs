using System;
using System.Collections;
using System.Linq;
using System.IO;
using Mono.Unix;
using ByteSizeLib;

namespace Wii_U_Zip
{
	public partial class MainWindow : Gtk.Window
	{
		private Gtk.NodeStore nodeStore;
        private string WorkingDirectory;
		public MainWindow() :
				base(Gtk.WindowType.Toplevel)
		{
			this.Build();
			init();
			openFile(null);
		}

		public MainWindow(string filename) :
				base(Gtk.WindowType.Toplevel)
		{
			this.Build();
			init();
			openFile(filename);
		}

		protected void init()
		{
			nodeStore = new Gtk.NodeStore(typeof(TreeNode));
			mainTreeView.NodeStore = nodeStore;
			mainTreeView.AppendColumn(Catalog.GetString("Name"), new Gtk.CellRendererText(), "text", 0);
			mainTreeView.AppendColumn(Catalog.GetString("Size"), new Gtk.CellRendererText(), "text", 1);
			mainTreeView.ShowAll();
			mainTreeView.NodeSelection.Mode = Gtk.SelectionMode.Multiple;
		}

		override protected bool OnDeleteEvent(Gdk.Event ev)
		{
			Gtk.Application.Quit();
			return true;
		}

		protected void onOpen(object sender, EventArgs e)
		{
			Gtk.FileChooserDialog chooser = new Gtk.FileChooserDialog(
				Catalog.GetString("Open archive"),
				this,
				Gtk.FileChooserAction.Open,
				Catalog.GetString("Cancel"), Gtk.ResponseType.Cancel,
				Catalog.GetString("Open"), Gtk.ResponseType.Accept
			);
			Gtk.FileFilter filterSupported = new Gtk.FileFilter();
			filterSupported.AddPattern("*.szs");
			filterSupported.AddPattern("*.sarc");
            filterSupported.AddPattern("*.carc");
            filterSupported.AddPattern("*.pack");
            filterSupported.AddPattern("*.bars");
            filterSupported.AddPattern("*.bgenv");
            filterSupported.Name = Catalog.GetString("All supported files");

			Gtk.FileFilter filterAll = new Gtk.FileFilter();
			filterAll.Name = Catalog.GetString("All files");
			filterAll.AddPattern("*");

			Gtk.FileFilter filterSarc = new Gtk.FileFilter();
			filterSarc.AddPattern("*.sarc");
            filterSarc.AddPattern("*.pack");
            filterSarc.AddPattern("*.arc");
            filterSarc.AddPattern("*.bars");
            filterSarc.AddPattern("*.bgenv");
			filterSarc.Name = "SARC archive";

			Gtk.FileFilter filterSzs = new Gtk.FileFilter();
			filterSzs.AddPattern("*.szs");
            filterSzs.AddPattern("*.carc");
			filterSzs.Name = "SZS/CARC file";

			chooser.AddFilter(filterSupported);
			chooser.AddFilter(filterAll);
			chooser.AddFilter(filterSarc);
			chooser.AddFilter(filterSzs);
			if (chooser.Run() == (int)Gtk.ResponseType.Accept)
			{
                // Good!
                this.WorkingDirectory = chooser.Filename;
				openFile(chooser.Filename);
			}
			chooser.Destroy();
		}

		protected void openFile(string fileName)
		{
			nodeStore.Clear();
			if (String.IsNullOrEmpty(fileName))
			{
				
				//extractAllAction.Activated = false;
				return;
			}
			if (System.IO.Path.GetExtension(fileName).Equals(".szs") ||
                System.IO.Path.GetExtension(fileName).Equals(".carc"))
			{
				byte[] szs = YAZ0.Decompress(File.ReadAllBytes(fileName));
				Console.WriteLine("YAZ0 decompressed");
				if ((new FileData(szs)).readString(0, 4).Equals("SARC"))
				{
					SARC sarc = new SARC();
					sarc.Read(szs);
					//globalPadding = sarc.padding;
					endianToggle.Active = (sarc.endian == Endianness.Big);
					foreach (string name in sarc.files.Keys)
					{
						nodeStore.AddNode(new TreeNode(name, sarc.files[name]));
						//treeView1.Nodes.Add(new TreeNode(name) { Tag = sarc.files[name] });
					}
				}
				else
				{
					nodeStore.AddNode(new TreeNode("contents.bin", szs));
					//treeView1.Nodes.Add(new TreeNode("contents.bin") { Tag = szs });
				}
			}
			else
			{
				SARC sarc = new SARC(fileName);
				//globalPadding = sarc.padding;
				endianToggle.Active = (sarc.endian == Endianness.Big);
				foreach (string name in sarc.files.Keys)
				{
					nodeStore.AddNode(new TreeNode(name, sarc.files[name]));
					//treeView1.Nodes.Add(new TreeNode(name) { Tag = sarc.files[name] });
				}
			}

		}

		protected void createFile(string path, byte[] data)
		{
			if (!String.IsNullOrWhiteSpace(System.IO.Path.GetDirectoryName(path)))
			{
				Directory.CreateDirectory(System.IO.Path.GetDirectoryName(path));
			}
			File.WriteAllBytes(path, data);
		}

		[Gtk.TreeNode(ListOnly = true)]
		protected class TreeNode : Gtk.TreeNode
		{
			public TreeNode(string path, byte[] data)
			{
				this.name = path;
				this.size = ByteSize.FromBytes(data.Length).ToString();
				this.data = data;
			}

			private string name;
			[Gtk.TreeNodeValue(Column = 0)]
			public string Name
			{
				get { return this.name; }
				set { this.Name = value; }
			}

			private string size;
			[Gtk.TreeNodeValue(Column = 1)]
			public string Size
			{
				get { return this.size; }
				set { this.size = value; }
			}

			private byte[] data;
			public byte[] Data
			{
				get { return this.data; }
			}
		}

		protected void onExtractAllPressed(object sender, EventArgs e)
		{
            string basePath = GetSavePath();
            if (String.IsNullOrEmpty(basePath)) return;
			Console.WriteLine("Extracting to " + basePath);
			foreach (TreeNode node in nodeStore)
			{
				createFile(basePath + node.Name, node.Data);
			}
			Console.WriteLine("Done.");
		}

		protected void onExtractPressed(object sender, EventArgs e)
		{
            string basePath = GetSavePath();
            if (String.IsNullOrEmpty(basePath)) return;
            Gtk.TreePath[] selection = mainTreeView.Selection.GetSelectedRows();
			foreach (Gtk.TreePath path in selection)
			{
				TreeNode node = (TreeNode)nodeStore.GetNode(path);
				createFile(basePath + node.Name, node.Data);
			}
		}

		protected void OnQuitPressed(object sender, EventArgs e)
		{
			Gtk.Application.Quit();
		}

		protected void OnSaveAsPressed(object sender, EventArgs e)
		{
			Gtk.FileChooserDialog saveDialog = new Gtk.FileChooserDialog(
				Catalog.GetString("Save as"),
				this,
				Gtk.FileChooserAction.Save,
				Catalog.GetString("Cancel"), Gtk.ResponseType.Cancel,
				Catalog.GetString("Save"), Gtk.ResponseType.Accept
			);
			if (saveDialog.Run() == (int) Gtk.ResponseType.Accept) {
				//
			}
		}
        private String GetSavePath()
        {
            string fileName = "";
            Gtk.FileChooserDialog chooser = new Gtk.FileChooserDialog(
                Catalog.GetString("Select extract location"),
                this,
                Gtk.FileChooserAction.SelectFolder,
                Catalog.GetString("Cancel"), Gtk.ResponseType.Cancel,
                Catalog.GetString("Open"), Gtk.ResponseType.Accept
            );
            chooser.SetFilename(this.WorkingDirectory);
            if (chooser.Run() == (int)Gtk.ResponseType.Accept)
            {
                // Good!
                fileName = chooser.Filename + "/";
            }
            chooser.Destroy();
            return fileName;
        }
    }
   
}
