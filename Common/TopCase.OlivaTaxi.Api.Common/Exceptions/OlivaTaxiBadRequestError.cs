using System.Net;

namespace TopCase.OlivaTaxi.Api.Common.Exceptions
{
    public class OlivaTaxiBadRequestError : OlivaTaxiError
    {
        public OlivaTaxiBadRequestError(int status, string title, string detail = null)
            : base(status, title, HttpStatusCode.BadRequest, detail)
        {
        }
    }
}