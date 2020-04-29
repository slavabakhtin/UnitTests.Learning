using System;
using System.IO;
using Topshelf;

namespace Example.Api
{
    public class Service : ServiceControl
    {
        private const string LogFileLocation = @"D:\TestService\temp.txt";

        private void Log(string logMessage)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(LogFileLocation));
            File.AppendAllText(LogFileLocation, DateTime.UtcNow.ToString() + " : " + logMessage + Environment.NewLine);
        }

        public bool Start(HostControl hostControl)
        {
            Log($"Worker running at: {DateTimeOffset.Now}");
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            Log($"Worker stopping at: {DateTimeOffset.Now}");
            return true;
        }
    }
}
