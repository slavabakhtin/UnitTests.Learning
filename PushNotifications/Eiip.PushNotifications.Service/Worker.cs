using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Topshelf;

namespace Eiip.PushNotifications.Service
{
    public class Worker : ServiceControl
    {
        private const string LogFileLocation = @"D:\log.txt";

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
