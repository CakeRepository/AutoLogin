using System;

namespace AutoLoginBuilder
{
    class CMDCli
    {
        Worker wkr = new Worker();
        public void arguments(string[] args)
        {
            if (args[0] == "remove")
            {
                remover();
            }
            else if (args[0] == @"/?")
            {
                Console.WriteLine("CMD : Results");
                Console.WriteLine("================================================================");
                Console.WriteLine("================================================================");
                Console.WriteLine("AutoLoginBuilder.exe remove : WILL REMOVE AUTOLOGIN");
                Console.WriteLine("AutoLoginBuilder.exe USERNAME PASSWORD : Will add Auto Login for local users");
                Console.WriteLine("AutoLoginBuilder.exe DOMAIN USERNAME PASSWORD : Will add Auto Login for Domain Users");
                Console.WriteLine("================================================================");
                Console.WriteLine("================================================================");
            }
            else if (args.Length == 2)
            {
                adderNoDomain(args[0], args[1]);
            }
            else if(args.Length == 3)
            {
                adder(args[0], args[1], args[2]);
            }
            else
            {
                throw new ArgumentOutOfRangeException("num2 > double.MaxValue - num1.");
            }
        }
        private void adderNoDomain(string username,string password)
        {
            wkr.autoLoginCommand(username, password);
        }
        private void adder(string domain,string username,string password)
        {
            wkr.autoLoginCommand(username, password, domain);
        }
        private void remover()
        {
            wkr.autoLoginCommand();
        }
    }
}
