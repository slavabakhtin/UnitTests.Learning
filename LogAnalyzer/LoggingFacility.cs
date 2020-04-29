using NUnit.Framework.Internal;


namespace LogAnalyzer
{
    public class LoggingFacility
    {
        public static void Log(string text)
        {
            logger.Info(text);
        }

        public static ILogger logger { get; set; }
    }
}
