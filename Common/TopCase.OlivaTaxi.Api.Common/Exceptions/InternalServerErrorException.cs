using System;

namespace TopCase.OlivaTaxi.Api.Common.Exceptions
{
    public class InternalServerErrorException : HttpException
    {
        public InternalServerErrorException(OlivaTaxiInternalServerError error)
            : base(error)
        {
        }

        public InternalServerErrorException(OlivaTaxiInternalServerError error, Exception? innerException) : base(error, innerException)
        {
        }
    }
}