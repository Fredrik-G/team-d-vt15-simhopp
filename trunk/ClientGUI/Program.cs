using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientGUI.View;
using ClientGUI.Presenter;

namespace ClientGUI
{
    public class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var judgeClient = new JudgeClient();
            var client = new Client();
            PresenterJudgeClient presenterJudgeClient = new PresenterJudgeClient(judgeClient, client);

            Application.Run(judgeClient);
        }
    }
}
