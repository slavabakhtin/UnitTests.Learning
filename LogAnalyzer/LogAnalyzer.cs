using Microsoft.Extensions.Logging;

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
