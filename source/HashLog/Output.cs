using System;
using System.Collections.Generic;
using System.Text;
using HashLog.Outputs;

namespace HashLog
{
    class Output
    {
        public static void Setup(string projectName)
        {
            FileOutput.Setup(projectName);
            ConsoleOutput.Setup(projectName);
        }

        public static void Send(string message)
        {
            FileOutput.Send(message);
            ConsoleOutput.Send(message);
        }
    }
}
