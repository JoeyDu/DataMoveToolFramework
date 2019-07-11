using System;
using System.Collections.Generic;
using System.Configuration.Install;
using System.IO;
using System.ServiceProcess;
using System.Text;

namespace TaskConsole
{
    class WinServiceManager : IWinServiceManager
    {
        static string ServiceName = "";//工具自定义名称
        public void Install()
        {
            string serviceName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "GTaskService.exe");
            if (!File.Exists(serviceName))
            {
                Console.WriteLine("TaskService.exe文件不存在！");
                return;
            }
            try {
                TransactedInstaller transactedInstaller = new TransactedInstaller();
                AssemblyInstaller assemblyInstall = new AssemblyInstaller(serviceName, null);
                transactedInstaller.Installers.Add(assemblyInstall);
                transactedInstaller.Install(new System.Collections.Hashtable());
                Console.WriteLine("\r\n~~~~~~~~~~服务安装完成~~~~~~~~~~");
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null
                   && ex.InnerException.Message.Contains("拒绝访问"))
                    Console.WriteLine("请右键“以管理员身份运行”！");
                else
                    Console.WriteLine(ex);

                Console.WriteLine("\r\n~~~~~~~~~~服务安装失败！~~~~~~~~~~");
            }
        }

        public void Start()
        {
            try
            {
                ServiceController ctrl = new ServiceController(ServiceName);
                if (ctrl.Status != ServiceControllerStatus.Running
                    && ctrl.Status != ServiceControllerStatus.StartPending)
                {
                    ctrl.Start();
                }
                ctrl.Refresh();
                Console.WriteLine("服务已启动！");
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null
                    && ex.InnerException.Message.Contains("拒绝访问"))
                    Console.WriteLine("请右键“以管理员身份运行”！");
                else
                    Console.WriteLine(ex);
            }
        }

        public  void Stop()
        {
            try
            {
               
                ServiceController ctrl = new ServiceController(ServiceName);
                if (ctrl.Status != ServiceControllerStatus.Stopped
                    && ctrl.Status != ServiceControllerStatus.StopPending)
                {
                    ctrl.Stop();
                }
                ctrl.Refresh();
                Console.WriteLine("服务已停止！");
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null
                     && ex.InnerException.Message.Contains("拒绝访问"))
                    Console.WriteLine("请右键“以管理员身份运行”！");
                else
                    Console.WriteLine(ex);
            }
        }

        public void UnInstall()
        {
            string serviceFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "GTaskService.exe");
            if (!File.Exists(serviceFileName))
            {
                Console.WriteLine("文件GTaskService.exe不存在！");
                return;
            }

            try
            {
               
                string[] cmdline = { };
                TransactedInstaller transactedInstaller = new TransactedInstaller();
                AssemblyInstaller assemblyInstaller = new AssemblyInstaller(serviceFileName, cmdline);
                transactedInstaller.Installers.Add(assemblyInstaller);
                transactedInstaller.Uninstall(null);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null
                    && ex.InnerException.Message.Contains("拒绝访问"))
                    Console.WriteLine("请右键“以管理员身份运行”！");
                else
                    Console.WriteLine(ex);

                Console.WriteLine("\r\n~~~~~~~~~~服务卸载失败！~~~~~~~~~~");
            }
        }
    }
}
