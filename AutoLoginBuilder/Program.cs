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
                cmd.arguments(args);
            }
        }
    }
}
