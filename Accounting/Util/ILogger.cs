using System;
using System.Collections.Generic;
using System.Text;

namespace Accounting.Util
{
    public interface ILogger
    {
        void Log(string log);
        void LogWithExit(string log);
    }
}
