using System;

namespace Eiip.Common.Models
{
    public static class AdditionalEnvironments
    {
        public const string RemoteEnvPrefix = "Remote_";

        public const string Local = nameof(Local);
        public const string QA = nameof(QA);

        public static bool IsLocal(string environmentName)
        {
            return string.Equals(environmentName, Local, StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsQa(string environmentName)
        {
            return string.Equals(environmentName, QA, StringComparison.OrdinalIgnoreCase);
        }
    }
}