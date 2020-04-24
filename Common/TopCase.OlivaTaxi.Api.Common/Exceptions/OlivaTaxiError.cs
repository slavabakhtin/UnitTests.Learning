using System.Net;

namespace TopCase.OlivaTaxi.Api.Common.Exceptions
{
    public class OlivaTaxiError
    {
        public OlivaTaxiError(int status, string title, HttpStatusCode statusCode, string detail = null)
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