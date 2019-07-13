using System;
using Gtk;

namespace Wii_U_Zip
{
    static class Program
	{

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //[STAThread]
        static void Main(string[] args)
		{
			Application.Init();
			MainWindow mainWindow;
			if (args.Length <= 0)
			{
				mainWindow = new MainWindow();
			}
			else
			{
				mainWindow = new MainWindow(args[0]);
			}
			Application.Run();
        }
    }
}
