namespace Eiip.Api.Common.Exceptions
{
    public static class EiipErrors
    {
        public enum StatusCodes
        {
            FirebaseUserNotFoundInDatabase = 5001,
            RequiredCacheValueIsMissing = 5002
        }
    }
}