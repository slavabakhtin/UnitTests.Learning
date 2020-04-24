using System;

namespace TopCase.OlivaTaxi.Api.Common.Exceptions
{
    public class BadRequestException : HttpException
    {
        public BadRequestException(OlivaTaxiBadRequestError error)
            : base(error)
        {
        }

        public BadRequestException(OlivaTaxiBadRequestError error, Exception? innerException) : base(error, innerException)
        {
        }
    }
}