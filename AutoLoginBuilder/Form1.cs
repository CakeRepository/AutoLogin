using System;
using System.Windows.Forms;

namespace AutoLoginBuilder
{
    public partial class Form1 : Form
    {
        string[] args = Environment.GetCommandLineArgs();
        Worker wkr = new Worker();
        char p = '"';
        public Form1()
        {
            InitializeComponent();
        }
        
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            wkr.ExecuteCommand("REG ADD "+p+"HKLM\\Software\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon"+p+" /v AutoAdminLogon /t REG_SZ /d 0 /f /reg:64");
            wkr.ExecuteCommand("REG ADD " + p + "HKLM\\Software\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon" + p + " /v DefaultUserName /t REG_SZ /d "+p+p+"  /f /reg:64");
            wkr.ExecuteCommand("REG ADD " + p + "HKLM\\Software\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon" + p + " /v DefaultDomainName /t REG_SZ /d " + p + p + " /f /reg:64");
            wkr.ExecuteCommand("REG ADD "+p+"HKLM\\Software\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon"+p+" /v DefaultPassword /t REG_SZ /d "+p+p+" /f /reg:64");
        }

        private void BuilderButtonClick_Click(object sender, EventArgs e)
        {
            wkr.ExecuteCommand("REG ADD " + p + "HKLM\\Software\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon" + p + " /v AutoAdminLogon /t REG_SZ /d 1 /f /reg:64");
            wkr.ExecuteCommand("REG ADD " + p + "HKLM\\Software\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon" + p + " /v DefaultUserName /t REG_SZ /d " + UsernameTextBox.Text + "  /f /reg:64");
            wkr.ExecuteCommand("REG ADD " + p + "HKLM\\Software\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon" + p + " /v DefaultDomainName /t REG_SZ /d " + DomainTextBox.Text + " /f /reg:64");
            wkr.ExecuteCommand("REG ADD " + p + "HKLM\\Software\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon" + p + " /v DefaultPassword /t REG_SZ /d " + PasswordTextBox.Text + " /f /reg:64");
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            
            PasswordTextBox.PasswordChar = '*';
            string[] strArr = wkr.defaultDomain(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            UsernameTextBox.Text = strArr[1];
            DomainTextBox.Text = strArr[0];
        }

    }
}
