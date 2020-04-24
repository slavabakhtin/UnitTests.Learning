using System;
using System.Net.Mime;
using System.Threading.Tasks;
using Eiip.Api.Common.Exceptions;
using Eiip.Common.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Eiip.Api.Common.Middlewares
{
    public class HttpExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly OlivaTaxiProblemDetailsFactory _problemDetailsFactory;
        private readonly ILogger<HttpExceptionMiddleware> _logger;

        public HttpExceptionMiddleware(ILogger<HttpExceptionMiddleware> logger, RequestDelegate next, OlivaTaxiProblemDetailsFactory problemDetailsFactory)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _problemDetailsFactory = problemDetailsFactory;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (HttpException ex)
            {
                var response = context.Response;

                if (response.HasStarted)
                {
                    _logger.LogWarning("The response has already started, the http status code middleware will not be executed.");
                    throw;
                }

                var detailsJson = _problemDetailsFactory.FromEiipError(context, ex.Error).ToJson();
                
                if (ex.GetType() != typeof(BadRequestException))
                {
                    if (ex.GetType() == typeof(InternalServerErrorException))
                    {
                        _logger.LogError($"{ex.GetType()} error occured. Details: {detailsJson}");
                    }
                    throw;
                }

                _logger.LogWarning($"{ex.GetType()} error occured. Details: {detailsJson}");
                
                response.Clear();

                response.StatusCode = (int)ex.Error.StatusCode;
                response.ContentType = MediaTypeNames.Application.Json;
                await response.WriteAsync(detailsJson);
            }
        }
    }
}
