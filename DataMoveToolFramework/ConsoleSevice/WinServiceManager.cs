using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleSevice
{
    class WinServiceManager : IWinServiceManager
    {
        public void Install()
        {
            string serviceName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "GTaskService.exe");
            if (!File.Exists(serviceName))
            {
                Console.WriteLine("TaskService.exe文件不存在！");
                return;
            }
            try {
                string[] cmdline = { };

                TransactedInstaller t = new TransactedInstaller();
            }
            catch(Exception ex)
            { }
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public void UnInstall()
        {
            throw new NotImplementedException();
        }
    }
}
