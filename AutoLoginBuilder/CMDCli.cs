using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLoginBuilder
{
    class CMDCli
    {
        char p = '"';
        Worker wkr = new Worker();
        public void arguments(string[] args)
        {
            if (args[0] == "remove")
            {
                remover();
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
        private void adder(string domain,string username,string password)
        { 
            wkr.ExecuteCommand("REG ADD " + p + "HKLM\\Software\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon" + p + " /v AutoAdminLogon /t REG_SZ /d 1 /f /reg:64");
            wkr.ExecuteCommand("REG ADD " + p + "HKLM\\Software\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon" + p + " /v DefaultUserName /t REG_SZ /d " + username + "  /f /reg:64");
            wkr.ExecuteCommand("REG ADD " + p + "HKLM\\Software\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon" + p + " /v DefaultDomainName /t REG_SZ /d " + domain + " /f /reg:64");
            wkr.ExecuteCommand("REG ADD " + p + "HKLM\\Software\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon" + p + " /v DefaultPassword /t REG_SZ /d " + password + " /f /reg:64");
        }
        private void remover()
        {
            wkr.ExecuteCommand("REG ADD " + p + "HKLM\\Software\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon" + p + " /v AutoAdminLogon /t REG_SZ /d 0 /f /reg:64");
            wkr.ExecuteCommand("REG ADD " + p + "HKLM\\Software\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon" + p + " /v DefaultUserName /t REG_SZ /d " + p + p + "  /f /reg:64");
            wkr.ExecuteCommand("REG ADD " + p + "HKLM\\Software\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon" + p + " /v DefaultDomainName /t REG_SZ /d " + p + p + " /f /reg:64");
            wkr.ExecuteCommand("REG ADD " + p + "HKLM\\Software\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon" + p + " /v DefaultPassword /t REG_SZ /d " + p + p + " /f /reg:64");
        }
    }
}
