using System.Net;

namespace Eiip.Api.Common.Exceptions
{
    public class EiipInternalServerError : EiipError
    {
        public EiipInternalServerError(EiipErrors.StatusCodes statusCode, string title, string detail = null)
            : base((int)statusCode, title, HttpStatusCode.InternalServerError, detail)
        {
        }
    }
}