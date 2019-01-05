using System;
using System.Windows.Forms;

namespace AutoLoginBuilder
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            else
            {
                CMDCli cmd = new CMDCli();
                if (args[0] == @"/?")
                {
                    MessageBox.Show(
                    "CMD : Results" + "\n" +
                    "==============================================" + "\n" +
                    "==============================================" + "\n" +
                    "AutoLoginBuilder.exe remove : WILL REMOVE AUTOLOGIN" + "\n" +
                    "AutoLoginBuilder.exe USERNAME PASSWORD : Will add Auto Login for local users" + "\n" +
                    "AutoLoginBuilder.exe DOMAIN USERNAME PASSWORD : Will add Auto Login for Domain Users" + "\n" +
                    "==============================================" + "\n" +
                    "==============================================");
                }

                else
                {
                    cmd.arguments(args);
                }
            }
        }
    }
}
