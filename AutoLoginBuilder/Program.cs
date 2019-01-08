using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using NDesk.Options;

namespace AutoLoginBuilder
{
    static class Program
    {

        //Setup for Redirect to MS Console
        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
        private const int ATTACH_PARENT_PROCESS = -1;


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
                bool show_help = false;
                bool remove = false;

                string username = null;
                string password = null;
                string domain = "";
                Worker wkr = new Worker();

                var p = new OptionSet()
            {
                {
                   "h|help",  "Shows help msg and exits",
                    v => show_help = v != null
                },
                {
                   "r|remove",  "Removes Auto Login",
                    v => remove = v != null
                },
                {
                   "u|username=",  "Computer Account being set for Auto Login",
                    v => username = v 
                },
                {
                   "p|password=",  "Password for account being set for Auto Login",
                    v => password = v 
                },
                {
                   "d|domain=",  "Domain for account being set for Auto Login.\n"+
                   "Leave Blank for local account",
                    v => domain = v 
                },
                
            };
                List<string> extra;
                try
                {
                    extra = p.Parse(args);
                }
                catch (OptionException e)
                {
                    Console.WriteLine(e.Message);
                }
                if (show_help)
                {
                    //Redirect to MS Console
                    AttachConsole(ATTACH_PARENT_PROCESS);
                    Console.WriteLine();
                    ShowHelp(p);
                    Environment.Exit(0);
                }
                else if (remove)
                {
                    int success = wkr.autoLoginCommand();
                }
                else if (username != null && password != null)
                {
                    int success = wkr.autoLoginCommand(username, password, domain);
                }
            }
        }
        static void ShowHelp(OptionSet p)
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("      Welcome to the help for this auto Login");
            Console.WriteLine("     Remember domain can be blank for localhost");
            Console.WriteLine();
            Console.WriteLine("Options:");
            p.WriteOptionDescriptions(Console.Out);
            Environment.Exit(0);
        }
    }
}
