using System;

namespace Eiip.Api.Common.Exceptions
{
    public class BadRequestException : HttpException
    {
        public BadRequestException(EiipBadRequestError error)
            : base(error)
        {
        }

        public BadRequestException(EiipBadRequestError error, Exception? innerException) : base(error, innerException)
        {
        }
    }
}