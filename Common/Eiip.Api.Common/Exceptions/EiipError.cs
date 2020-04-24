using System.Net;

namespace Eiip.Api.Common.Exceptions
{
    public class EiipError
    {
        public EiipError(int status, string title, HttpStatusCode statusCode, string detail = null)
        {
            Status = status;
            Title = title;
            StatusCode = statusCode;
            Detail = detail;
        }

        public HttpStatusCode StatusCode { get; }
        public string Title { get; }
        public int Status { get; }
        public string Detail { get; set; }
    }
}