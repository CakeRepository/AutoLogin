namespace AutoLoginBuilder
{
    class Worker
    {
        /// <summary>
        /// Runs CMD in the background
        /// </summary>
        /// <param name="Command">CMD to run in CMD prompt</param>
        public void ExecuteCommand(string Command)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/K " + Command;
            process.StartInfo = startInfo;
            process.Start();
            process.Close();
        }
        public string[] defaultDomain(string user)
        {
            char p = '\\';
            string[] domainSplit = user.Split(p);
            return domainSplit;
        }
    }
}
