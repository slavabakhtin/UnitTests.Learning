using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TopCase.OlivaTaxi.Api.Common.Exceptions;

namespace TopCase.OlivaTaxi.Api.Common.Middlewares
{
    public class OlivaTaxiProblemDetailsFactory
    {
        public ProblemDetails FromOlivaTaxiError(HttpContext httpContext, OlivaTaxiError error)
        {
            var problemDetails = new ProblemDetails()
            {
                Status = error.Status,
                Title = error.Title,
                Detail = error.Detail
            };

            var traceId = Activity.Current?.Id ?? httpContext?.TraceIdentifier;
            if (traceId != null)
            {
                problemDetails.Extensions["traceId"] = traceId;
            }

            return problemDetails;
        }
    }
}