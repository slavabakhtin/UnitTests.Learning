using System.Net;

namespace Eiip.Api.Common.Exceptions
{
    public class EiipBadRequestError : EiipError
    {
        public EiipBadRequestError(int status, string title, string detail = null)
            : base(status, title, HttpStatusCode.BadRequest, detail)
        {
        }
    }
}