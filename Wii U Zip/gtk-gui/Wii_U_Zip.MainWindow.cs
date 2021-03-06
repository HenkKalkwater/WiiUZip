
// This file has been generated by the GUI designer. Do not modify.
namespace Wii_U_Zip
{
	public partial class MainWindow
	{
		private global::Gtk.UIManager UIManager;

		private global::Gtk.Action saveAsAction;

		private global::Gtk.Action openAction;

		private global::Gtk.Action saveAsAction1;

		private global::Gtk.Action addAction;

		private global::Gtk.Action removeAction;

		private global::Gtk.Action convertAction;

		private global::Gtk.ToggleAction endianToggle;

		private global::Gtk.Action extractAction;

		private global::Gtk.Action extractAllAction;

		private global::Gtk.VBox mainVBox;

		private global::Gtk.Toolbar toolbar1;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Gtk.NodeView mainTreeView;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Wii_U_Zip.MainWindow
			this.UIManager = new global::Gtk.UIManager();
			global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup("Default");
			this.saveAsAction = new global::Gtk.Action("saveAsAction", global::Mono.Unix.Catalog.GetString("Save As"), null, "gtk-save-as");
			this.saveAsAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Save As");
			this.saveAsAction.Visible = false;
			this.saveAsAction.VisibleHorizontal = false;
			this.saveAsAction.VisibleVertical = false;
			this.saveAsAction.VisibleOverflown = false;
			w1.Add(this.saveAsAction, null);
			this.openAction = new global::Gtk.Action("openAction", global::Mono.Unix.Catalog.GetString("Open"), null, "gtk-open");
			this.openAction.IsImportant = true;
			this.openAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Open");
			w1.Add(this.openAction, "<Primary>o");
			this.saveAsAction1 = new global::Gtk.Action("saveAsAction1", global::Mono.Unix.Catalog.GetString("Save As"), null, "gtk-save-as");
			this.saveAsAction1.ShortLabel = global::Mono.Unix.Catalog.GetString("Save As");
			w1.Add(this.saveAsAction1, "<Primary>s");
			this.addAction = new global::Gtk.Action("addAction", null, null, "gtk-add");
			this.addAction.Visible = false;
			this.addAction.VisibleHorizontal = false;
			this.addAction.VisibleVertical = false;
			this.addAction.VisibleOverflown = false;
			w1.Add(this.addAction, null);
			this.removeAction = new global::Gtk.Action("removeAction", null, null, "gtk-remove");
			this.removeAction.Visible = false;
			this.removeAction.VisibleHorizontal = false;
			this.removeAction.VisibleVertical = false;
			this.removeAction.VisibleOverflown = false;
			w1.Add(this.removeAction, null);
			this.convertAction = new global::Gtk.Action("convertAction", global::Mono.Unix.Catalog.GetString("Replace"), null, "gtk-convert");
			this.convertAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Replace");
			this.convertAction.Visible = false;
			this.convertAction.VisibleHorizontal = false;
			this.convertAction.VisibleVertical = false;
			this.convertAction.VisibleOverflown = false;
			w1.Add(this.convertAction, null);
			this.endianToggle = new global::Gtk.ToggleAction("endianToggle", global::Mono.Unix.Catalog.GetString("Big Endian"), null, null);
			this.endianToggle.ShortLabel = global::Mono.Unix.Catalog.GetString("Big Endian");
			w1.Add(this.endianToggle, null);
			this.extractAction = new global::Gtk.Action("extractAction", global::Mono.Unix.Catalog.GetString("Extract"), global::Mono.Unix.Catalog.GetString("Extract the selected file"), "gtk-dnd");
			this.extractAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Extract");
			w1.Add(this.extractAction, "<Primary>e");
			this.extractAllAction = new global::Gtk.Action("extractAllAction", global::Mono.Unix.Catalog.GetString("Extract All"), null, "gtk-dnd-multiple");
			this.extractAllAction.IsImportant = true;
			this.extractAllAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Extract All");
			w1.Add(this.extractAllAction, "<Primary>e");
			this.UIManager.InsertActionGroup(w1, 0);
			this.AddAccelGroup(this.UIManager.AccelGroup);
			this.Name = "Wii_U_Zip.MainWindow";
			this.Title = global::Mono.Unix.Catalog.GetString("Wii U Zip");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child Wii_U_Zip.MainWindow.Gtk.Container+ContainerChild
			this.mainVBox = new global::Gtk.VBox();
			this.mainVBox.Name = "mainVBox";
			this.mainVBox.Spacing = 6;
			// Container child mainVBox.Gtk.Box+BoxChild
			this.UIManager.AddUiFromString(@"<ui><toolbar name='toolbar1'><toolitem name='openAction' action='openAction'/><toolitem name='saveAsAction' action='saveAsAction'/><separator/><toolitem name='extractAction' action='extractAction'/><toolitem name='extractAllAction' action='extractAllAction'/><separator/><toolitem name='addAction' action='addAction'/><toolitem name='removeAction' action='removeAction'/><toolitem name='convertAction' action='convertAction'/><separator/><toolitem name='endianToggle' action='endianToggle'/></toolbar></ui>");
			this.toolbar1 = ((global::Gtk.Toolbar)(this.UIManager.GetWidget("/toolbar1")));
			this.toolbar1.CanFocus = true;
			this.toolbar1.Name = "toolbar1";
			this.toolbar1.ShowArrow = false;
			this.toolbar1.ToolbarStyle = ((global::Gtk.ToolbarStyle)(2));
			this.mainVBox.Add(this.toolbar1);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.mainVBox[this.toolbar1]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child mainVBox.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.mainTreeView = new global::Gtk.NodeView();
			this.mainTreeView.CanFocus = true;
			this.mainTreeView.Name = "mainTreeView";
			this.GtkScrolledWindow.Add(this.mainTreeView);
			this.mainVBox.Add(this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.mainVBox[this.GtkScrolledWindow]));
			w4.Position = 1;
			this.Add(this.mainVBox);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 701;
			this.DefaultHeight = 308;
			this.Show();
			this.saveAsAction.Activated += new global::System.EventHandler(this.OnSaveAsPressed);
			this.openAction.Activated += new global::System.EventHandler(this.onOpen);
			this.extractAction.Activated += new global::System.EventHandler(this.onExtractPressed);
			this.extractAllAction.Activated += new global::System.EventHandler(this.onExtractAllPressed);
		}
	}
}
