using System;

namespace TopCase.OlivaTaxi.Api.Common.Exceptions
{
    public abstract class HttpException : ApplicationException
    {
        public OlivaTaxiError Error { get; }

        public HttpException(OlivaTaxiError error)
            : base(error.Title)
        {
            Error = error;
        }

        public HttpException(OlivaTaxiError error, Exception? innerException)
            : base(error.Title, innerException)
        {
            Error = error;
        }
    }
}