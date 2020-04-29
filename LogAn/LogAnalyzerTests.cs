using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;

namespace LogAn
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        [Test]
        public void Analyze_TooShortFileName_CallLogger()
        {
            ILogger<LogAnalyzer.LogAnalyzer> logger = Substitute.For<ILogger<LogAnalyzer.LogAnalyzer>>();
            LogAnalyzer.LogAnalyzer logAnalyzer = new LogAnalyzer.LogAnalyzer(logger);
            logAnalyzer.Analyze("a.txt");

            logger.Received().LogError("Too short filename:a.txt");
        }
    }
}
