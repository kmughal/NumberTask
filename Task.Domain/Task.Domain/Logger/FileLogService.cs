namespace Task.Domain
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Security.AccessControl;
    using static HelperFunctions;

    public class FileLogService : ILogService
    {
        static object lockObject = new object();
        const string FILE_NAME = "log.txt";
        string baseDirectory => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log");
        string fileFullPath => Path.Combine(baseDirectory, FILE_NAME);

        private void writeLogMessage(string message)
        {
            if (!Directory.Exists(baseDirectory))
            {
                Directory.CreateDirectory(baseDirectory);
            }

            using (var fileStream = new StreamWriter(fileFullPath, true))
            {
                fileStream.WriteLine(message);
            }
        }

        public void Log(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentNullException(string.Format(ErrorMessages.EMPTY_VALUE, nameof(message)));
            }
            lock (lockObject)
            {
                writeLogMessage(message.Trim());
            }
        }

        private string readLog()
        {
            if (!File.Exists(fileFullPath))
                ThrowFileNotFoundException(string.Format(ErrorMessages.NOT_VALID_PATH, fileFullPath));

            using (var fileStream = new StreamReader(fileFullPath))
            {
                return fileStream.ReadToEnd();
            }
        }

        public IList<string> GetAllLogs()
        {
            var logMessage = string.Empty;
            lock (lockObject)
            {
                logMessage = readLog();
            }

            if (string.IsNullOrEmpty(logMessage))
                ThrowNullArugmentException(string.Format(ErrorMessages.EMPTY_VALUE, nameof(logMessage)));

            return logMessage.Trim().Split('\n');
        }
    }
}