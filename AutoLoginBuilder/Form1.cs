using System;
using System.Windows.Forms;

namespace AutoLoginBuilder
{
    public partial class Form1 : Form
    {
        string[] args = Environment.GetCommandLineArgs();
        Worker wkr = new Worker();

        public Form1()
        {
            InitializeComponent();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            int success = wkr.autoLoginCommand();
        }

        private void BuilderButtonClick_Click(object sender, EventArgs e)
        {
            int success = wkr.autoLoginCommand(UsernameTextBox.Text, PasswordTextBox.Text, DomainTextBox.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PasswordTextBox.PasswordChar = '*';
            string[] strArr = wkr.defaultDomain(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            UsernameTextBox.Text = strArr[1];
            DomainTextBox.Text = strArr[0];
        }

        private void DomainTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
