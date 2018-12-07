//Copyright: Piotr Paszko, all rights reserved.
//License: GNU v.3

using System;
using System.Collections.Generic;
using System.Text;

namespace HashLog
{
    public class HashLog
    {
        /// <summary>
        /// Setups Hashlog console and file outputs.
        /// </summary>
        /// <param name="projectName">Name of your application used in console and log file.</param>
        public static void Setup(string projectName)
        {
            Output.Setup(projectName);
        }

        /// <summary>
        /// Logs exception with INFO prefix.
        /// </summary>
        /// <param name="exception">Exception to log</param>
        public static void LogInformation(Exception exception)
        {
            Log("INFO", exception);
        }

        /// <summary>
        /// Logs exception with WARNING prefix.
        /// </summary>
        /// <param name="exception">Exception to log</param>
        public static void LogWarning(Exception exception)
        {
            Log("WARNING", exception);
        }

        /// <summary>
        /// Logs exception with ERROR prefix.
        /// </summary>
        /// <param name="exception">Exception to log</param>
        public static void LogError(Exception exception)
        {
            Log("ERROR", exception);
        }

        /// <summary>
        /// Logs exception with FATAL ERROR prefix.
        /// </summary>
        /// <param name="exception">Exception to log</param>
        public static void LogFatalError(Exception exception)
        {
            Log("FATAL ERROR", exception);
        }

        private static void Log(string prefix, Exception exception)
        {
            string text = GetTimeText();
            text += String.Format(" [{0}]: ", prefix);
            text += MessageBuilder.BuildMessage(exception);
            Output.SendBoth(text, true);
        }

        private static string GetTimeText()
        {
            DateTime actualLocalDateTime = DateTime.Now.ToLocalTime();
            return String.Format("[{0}]", actualLocalDateTime.ToLongTimeString());
        }

        
    }
}
