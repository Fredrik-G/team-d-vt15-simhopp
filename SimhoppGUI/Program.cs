using System;
using System.Windows.Forms;
using SimhoppGUI.Model;
using SimhoppGUI.Presenter;
using SimhoppGUI.View;

namespace SimhoppGUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            StartScreen start = new StartScreen();
            Simhopp simhopp = new Simhopp();
            PresenterStartScreen presenter = new PresenterStartScreen(start, simhopp);
            Application.Run(start);

        }
    }
}
