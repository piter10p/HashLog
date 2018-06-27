using System;
using System.Collections.Generic;
using System.Text;
using HashLog.Outputs;

namespace HashLog
{
    public class Output
    {
        public static void Setup(string projectName)
        {
            FileOutput.Setup(projectName);
            ConsoleOutput.Setup(projectName);
        }

        public static void SendBoth(string message)
        {
            FileOutput.Send(message);
            ConsoleOutput.Send(message);
        }

        public static void SendConsole(string message)
        {
            ConsoleOutput.Send(message);
        }

        public static void SendFile(string message)
        {
            FileOutput.Send(message);
        }
    }
}
