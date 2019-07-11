using System;
using System.Collections.Generic;
using System.Text;

namespace TaskConsole
{
    interface IWinServiceManager
    {
        void Install();

        void UnInstall();

        void Start();

        void Stop();
    }
}
