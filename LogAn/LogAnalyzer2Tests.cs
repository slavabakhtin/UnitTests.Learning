using System;
using System.Collections.Generic;
using System.Text;
using LogAnalyzer;
using NUnit.Framework;

namespace LogAn
{
    [TestFixture]
    public class LogAnalyzer2Tests
    {
        [Test]
        public void Analyze_WebServiceThrows_SendsEmail()
        {
            FakeWebService fakeWebService = new FakeWebService();
            fakeWebService.ToThrow = new Exception("fake exception");

            FakeEmailService fakeEmailService = new FakeEmailService();
            
            LogAnalyzer2 logAnalyzer2 = new LogAnalyzer2(fakeWebService, fakeEmailService);
            string tooShortFilename = "abc.ext";
            logAnalyzer2.Analyze(tooShortFilename);

            StringAssert.Contains("someone@someone.com", fakeEmailService.To);
            StringAssert.Contains("fake exception", fakeEmailService.Body);
            StringAssert.Contains("can't log", fakeEmailService.Subject);

        } 
    }
}
