using System.Net;

namespace TopCase.OlivaTaxi.Api.Common.Exceptions
{
    public class OlivaTaxiInternalServerError : OlivaTaxiError
    {
        public OlivaTaxiInternalServerError(OlivaTaxiErrors.StatusCodes statusCode, string title, string detail = null)
            : base((int)statusCode, title, HttpStatusCode.InternalServerError, detail)
        {
        }
    }
}