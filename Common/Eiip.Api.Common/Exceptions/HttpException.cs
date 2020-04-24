using System;

namespace Eiip.Api.Common.Exceptions
{
    public abstract class HttpException : ApplicationException
    {
        public EiipError Error { get; }

        public HttpException(EiipError error)
            : base(error.Title)
        {
            Error = error;
        }

        public HttpException(EiipError error, Exception? innerException)
            : base(error.Title, innerException)
        {
            Error = error;
        }
    }
}