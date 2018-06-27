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
            //Prepare console and log file
            HashLog.HashLog.Setup("Test project");
            //Logs "Info." message with information prefix.
            HashLog.HashLog.LogInformation("Info.");
            //Logs "Warning." message with warning prefix.
            HashLog.HashLog.LogWarning("Warning.");
            //Logs "Error." message with error prefix.
            HashLog.HashLog.LogError("Error."); 

            //Sends "Non-log message." without any log information (like event time or prefix) to both outputs.
            HashLog.Output.SendBoth("Non-log message.");
            //Sends "Non-log message for console." without any log information to console output.
            HashLog.Output.SendConsole("Non-log message for console.");
            //Sends "Non-log message for file." without any log information to console output.
            HashLog.Output.SendFile("Non-log message for file.");


            //Prepare console and creates second log file (archive old one)
            HashLog.HashLog.Setup("Test project 2");
            //Logs "Fatal error." message with fatal error prefix and closes application.
            HashLog.HashLog.LogFatalError("Fatal error.");
        }
    }
}
