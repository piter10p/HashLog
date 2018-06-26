using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashLog.Outputs
{
    class ConsoleOutput
    {
        public static void Setup(string projectName)
        {
            Console.Title = projectName;
        }

        public static void Send(string message)
        {
            Console.WriteLine(message);
        }
    }
}
