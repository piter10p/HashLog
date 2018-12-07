using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace HashLog.Outputs
{
    class FileOutput
    {
        const string LogDirecotryName = "logs";
        const string LogFileName = "log";
        const string LogFileExtension = ".txt";

        public static void Setup(string projectName)
        {
            DirectoryInfo logsDirectoryInfo = SetupDirectory();
            SetupFile(projectName, logsDirectoryInfo);
        }

        public static void Send(string message, bool newLineAtEnd)
        {
            try
            {
                StreamWriter streamWriter = File.AppendText(LogDirecotryName + "/" + LogFileName + LogFileExtension);
                streamWriter.WriteLine(message);

                if(newLineAtEnd)
                    streamWriter.WriteLine();

                streamWriter.Close();
            }
            catch
            { }
        }

        private static DirectoryInfo SetupDirectory()
        {
            DirectoryInfo logsDirectoryInfo = new DirectoryInfo(LogDirecotryName);

            try
            {
                if (!logsDirectoryInfo.Exists)
                    logsDirectoryInfo.Create();
            }
            catch(Exception e)
            {
                throw new Exception("Cannot create logs directory. Details: " + e.Message);
            }

            return logsDirectoryInfo;
        }

        private static void SetupFile(string projectName, DirectoryInfo logsDirectoryInfo)
        {
            FileInfo logFileInfo = new FileInfo(logsDirectoryInfo.FullName + "/" + LogFileName + LogFileExtension);

            if (logFileInfo.Exists)
                ArchiveLogFile(logFileInfo, logsDirectoryInfo);

            CreateNewLogFile(projectName, logsDirectoryInfo);
        }

        private static void ArchiveLogFile(FileInfo logFileInfo, DirectoryInfo logsDirectoryInfo)
        {
            try
            {
                string logDate = GetDateFromLogTime(logFileInfo);
                AddDateToLogFileName(logFileInfo, logDate, logsDirectoryInfo);
            }
            catch
            {}
        }

        private static void AddDateToLogFileName(FileInfo logFileInfo, string logDate, DirectoryInfo logsDirectoryInfo)
        {
            string logDateWork = logDate.Replace(':', '_');
            string filePath = logsDirectoryInfo.FullName + "\\" + LogFileName + "-" + logDateWork + LogFileExtension;
            logFileInfo.MoveTo(filePath);
        }

        private static string GetDateFromLogTime(FileInfo logFileInfo)
        {
            List<string> fileLines = File.ReadLines(logFileInfo.FullName).ToList();
            return fileLines[1];
        }

        private static void CreateNewLogFile(string projectName, DirectoryInfo logsDirectoryInfo)
        {
            WriteHeaderToLogFile(logsDirectoryInfo.FullName + "/" + LogFileName + LogFileExtension, projectName);
        }

        private static void WriteHeaderToLogFile(string logFilePath, string projectName)
        {
            DateTime actualLocalDateTime =  DateTime.Now.ToLocalTime();

            string[] headerText =
            {
                "Project: " + projectName,
                actualLocalDateTime.ToShortDateString() + "-" + actualLocalDateTime.ToLongTimeString(),
                "",
                "Generated with: HashLog v. " + GetApplicationVersion() + ": https://github.com/piter10p/HashLog",
                "===========================================================================================",
                "",
                ""
            };

            System.IO.File.WriteAllLines(logFilePath, headerText);
        }

        private static string GetApplicationVersion()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            return fvi.FileVersion;
        }
    }
}
