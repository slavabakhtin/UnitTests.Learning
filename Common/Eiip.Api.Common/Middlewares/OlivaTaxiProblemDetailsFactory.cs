using System.Diagnostics;
using Eiip.Api.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eiip.Api.Common.Middlewares
{
    public class OlivaTaxiProblemDetailsFactory
    {
        public ProblemDetails FromEiipError(HttpContext httpContext, EiipError error)
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