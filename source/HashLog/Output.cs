using System;
using System.Collections.Generic;
using System.Text;
using HashLog.Outputs;

namespace HashLog
{
    public class Output
    {
        /// <summary>
        /// Setup of console and log file.
        /// </summary>
        /// <param name="projectName">Name of project displayed in console and log file.</param>
        public static void Setup(string projectName)
        {
            FileOutput.Setup(projectName);
            ConsoleOutput.Setup(projectName);
        }

        /// <summary>
        /// Sends message to both outputs, console and file.
        /// </summary>
        /// <param name="message">Message to send</param>
        /// <param name="newLineAtEnd">If true, additional new line character'll be added at the end of message</param>
        public static void SendBoth(string message, bool newLineAtEnd = false)
        {
            FileOutput.Send(message, newLineAtEnd);
            ConsoleOutput.Send(message, newLineAtEnd);
        }

        /// <summary>
        /// Sends message to console output.
        /// </summary>
        /// <param name="message">Message to send</param>
        /// <param name="newLineAtEnd">If true, additional new line character'll be added at the end of message</param>
        public static void SendConsole(string message, bool newLineAtEnd = false)
        {
            ConsoleOutput.Send(message, newLineAtEnd);
        }

        /// <summary>
        /// Sends message to file output.
        /// </summary>
        /// <param name="message">Message to send</param>
        /// <param name="newLineAtEnd">If true, additional new line character'll be added at the end of message</param>
        public static void SendFile(string message, bool newLineAtEnd = false)
        {
            FileOutput.Send(message, newLineAtEnd);
        }
    }
}
