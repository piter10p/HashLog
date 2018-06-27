//Copyright: Piotr Paszko, all rights reserved.
//License: GNU v.3

using System;
using System.Collections.Generic;
using System.Text;

namespace HashLog
{
    public class HashLog
    {
        public const string Version = "1.1";

        public static void Setup(string projectName)
        {
            Output.Setup(projectName);
        }

        public static void LogInformation(string message)
        {
            Log("INFO", message);
        }

        public static void LogWarning(string message)
        {
            Log("WARNING", message);
        }

        public static void LogError(string message)
        {
            Log("ERROR", message);
        }

        public static void LogFatalError(string message)
        {
            Log("FATAL ERROR", message);
            LogInformation("Fatal error occured. Application will be closed.");
            Environment.Exit(0);
        }

        private static void Log(string prefix, string message)
        {
            DateTime actualLocalDateTime = DateTime.Now.ToLocalTime();
            string text = "[" + actualLocalDateTime.ToLongTimeString() + "] " + prefix + ": " + message;
            Output.SendBoth(text);
        }
    }
}
