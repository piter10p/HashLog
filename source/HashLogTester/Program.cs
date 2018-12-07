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
            //Build exception for testing
            Exception innerExceptionLvl2 = new Exception("Inner exception, lvl. 2");
            Exception innerExceptionLvl1 = new Exception("Inner exception, lvl. 1", innerExceptionLvl2);
            Exception exception = new Exception("Test message", innerExceptionLvl1);
            exception.Data.Add("Key1", "Value1");
            exception.Data.Add("Key2", "Value2");
            exception.Source = "MySource";

            //Prepare console and log file
            HashLog.HashLog.Setup("Test project");
            //Logs exception with information prefix.
            HashLog.HashLog.LogInformation(exception);
            //Logs exception with warning prefix.
            HashLog.HashLog.LogWarning(exception);
            //Logs exception with error prefix.
            HashLog.HashLog.LogError(exception);
            //Logs exception with fatal error prefix.
            HashLog.HashLog.LogFatalError(exception);

            //Sends "Non-log message." without any log information (like event time or prefix) to both outputs.
            HashLog.Output.SendBoth("Non-log message.");
            //Sends "Non-log message for console." without any log information to console output.
            HashLog.Output.SendConsole("Non-log message for console.");
            //Sends "Non-log message for file." without any log information to console output.
            HashLog.Output.SendFile("Non-log message for file.");

            //For stop console
            Console.ReadKey();
        }
    }
}
