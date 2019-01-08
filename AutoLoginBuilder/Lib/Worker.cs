using Microsoft.Win32;
using System;

namespace AutoLoginBuilder
{
    class Worker
    {

        /// <summary>
        /// Adds autolin for user of your choice provide it with username, password and domain to create auto login set everything to blank if removing
        /// </summary>
        /// <param name="username">Username For Auto Logged in user if removing leave to blank</param>
        /// <param name="password">Password For Auto Logged in user if removing leave to blank</param>
        /// <param name="domain">Domain For Auto Logged in user if removing leave to blank</param>
        /// <returns>
        /// 1 for error
        /// 0 for success
        /// </returns>
        public int autoLoginCommand(string username = null, string password = null, string domain = null)
        {
            try
            {
                string winLogin = @"Software\Microsoft\Windows NT\CurrentVersion\Winlogon";
                RegistryKey key;
                key = Registry.LocalMachine.OpenSubKey(winLogin, true);
                if (username == null)
                {
                    if (key != null)
                    {
                        key.SetValue("AutoAdminLogon", "0", RegistryValueKind.String);
                        key.SetValue("DefaultUserName", "", RegistryValueKind.String);
                        key.SetValue("DefaultDomainName", "", RegistryValueKind.String);
                        key.SetValue("DefaultPassword", "", RegistryValueKind.String);
                        key.Close();
                    }
                }
                else
                {
                    if (key != null)
                    {
                        key.SetValue("AutoAdminLogon", "1", RegistryValueKind.String);
                        key.SetValue("DefaultUserName", username, RegistryValueKind.String);
                        key.SetValue("DefaultDomainName", domain, RegistryValueKind.String);
                        key.SetValue("DefaultPassword", password, RegistryValueKind.String);
                        key.Close();
                    }
                }
                return 0;
            }
            catch
            {
                return 1;
            }
        }

        public string[] defaultDomain(string user)
        {
            char p = '\\';
            string[] domainSplit = user.Split(p);
            return domainSplit;
        }
    }
}
