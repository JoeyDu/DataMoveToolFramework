using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSevice
{
    interface IWinServiceManager
    {
        void Install();

        void UnInstall();

        void Start();

        void Stop();
    }
}
