using System;
using LogAnalyzer;

namespace LogAn
{
    public class FakeWebService : IWebService
    {
        public Exception ToThrow;

        public void LogError(string message)
        {
            if (ToThrow != null)
            {
                throw ToThrow;
            }
        }
    }
}
