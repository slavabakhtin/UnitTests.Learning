using System;
using System.Collections.Generic;
using System.Text;

namespace LogAnalyzer
{
    public interface IWebService
    {
        void LogError(string message);
    }
}
