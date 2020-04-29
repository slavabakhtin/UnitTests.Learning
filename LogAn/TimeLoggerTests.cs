using System;
using LogAnalyzer;
using NUnit.Framework;

namespace LogAn
{
    [TestFixture]
    public class TimeLoggerTests
    {
        [Test]
        public void SettingSystemTime_Always_ChangesTime()
        {
            SystemTime.Set(new DateTime(2000, 1, 1));
            string output = TimeLogger.CreateMessage("a");
            StringAssert.Contains("1/1/2000", output);
        }

        [TearDown]
        public void AfterEachTest()
        {
            SystemTime.Reset();
        }
    }
}
