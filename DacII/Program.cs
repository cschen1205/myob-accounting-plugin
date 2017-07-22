using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DacII
{
    using Accounting.Bll;
    using DacII.Presenters;

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool uninstalling = false;
            //uninstaller part of the code
            string[] arguments= Environment.GetCommandLineArgs();
            foreach(string argument in arguments)
            {
                 if(argument.Split('=')[0].ToLower() == "/u")
                 {
                     uninstalling = true;
                    string guid = argument.Split('=')[1];
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.System);
                    System.Diagnostics.ProcessStartInfo si = new System.Diagnostics.ProcessStartInfo(path + "\\msiexec.exe", "/i " + guid);
                    System.Diagnostics.Process.Start(si);
                    Application.Exit();
                 }
            }

            if (uninstalling == false)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                AccLoader.Instance.Init(System.Windows.Forms.Application.StartupPath);

                Accountant acc = AccLoader.Instance.Load();

                ApplicationPresenter controller = new ApplicationPresenter(acc);

                Application.Run(new DacII.WinForms.FrmDac(controller));

                AccLoader.Instance.Unload();
            }
        }
    }
}
