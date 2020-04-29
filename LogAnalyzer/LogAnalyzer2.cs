using System;

namespace LogAnalyzer
{
    public class LogAnalyzer2
    {
        private readonly IWebService _webService;
        private readonly IEmailService _emailService;

        public LogAnalyzer2(IWebService webService, IEmailService emailService)
        {
            _webService = webService;
            _emailService = emailService;
        }

        public void Analyze(string filename)
        {
            if (filename.Length < 8)
            {
                try
                {
                    _webService.LogError("Too short filename:" + filename);
                }
                catch (Exception ex)
                {
                    _emailService.SendEmail("someone@someone.com", "can't log", ex.Message);
                }
            }
        }
    }
}
