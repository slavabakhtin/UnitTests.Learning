using System;

namespace Eiip.Api.Common.Exceptions
{
    public class InternalServerErrorException : HttpException
    {
        public InternalServerErrorException(EiipInternalServerError error)
            : base(error)
        {
        }

        public InternalServerErrorException(EiipInternalServerError error, Exception? innerException) : base(error, innerException)
        {
        }
    }
}