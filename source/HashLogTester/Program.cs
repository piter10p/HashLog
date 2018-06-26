using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashLogTester
{
    class Program
    {
        static void Main(string[] args)
        {
            HashLog.HashLog.Setup("Test project");
            HashLog.HashLog.LogInformation("Info.");
            HashLog.HashLog.LogWarning("Warning.");
            HashLog.HashLog.LogError("Error.");

            HashLog.HashLog.Setup("Test project 2");
            HashLog.HashLog.LogFatalError("Fatal error");
        }
    }
}
