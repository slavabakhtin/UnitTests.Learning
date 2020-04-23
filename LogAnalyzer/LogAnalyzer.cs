using System;
using System.IO;
using Microsoft.Extensions.Logging;
using NUnit.Framework.Internal;

namespace LogAnalyzer
{
    public class LogAnalyzer
    {
        private readonly ILogger<LogAnalyzer> _service;

        public LogAnalyzer(ILogger<LogAnalyzer> service)
        {
            _service = service;
        }

        public void Analyze(string fileName)
        {
            if (fileName.Length < 8)
            {
                _service.LogError("Too short filename:" + fileName);
            }
        }
    }
}
