using System;
using System.Windows.Forms;

using Simhopp.Presenter;
using Simhopp.Model;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

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
           // EditViewContest editView = new EditViewContest();
            Simhopp.Simhopp simhopp = new Simhopp.Simhopp();

            PresenterStartScreen presenterStartScreen = new PresenterStartScreen(start, simhopp);
           // PresenterEditViewContest presenterEditView = new PresenterEditViewContest(editView, presenterStartScreen);
            Application.Run(start);

        }
    }
}
