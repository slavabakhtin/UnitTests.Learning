using System;

namespace TopCase.OlivaTaxi.Api.Common.Exceptions
{
    public class OlivaTaxiException : ApplicationException
    {
        public OlivaTaxiException()
        {
        }

        public OlivaTaxiException(string? message) : base(message)
        {
        }

        public OlivaTaxiException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}