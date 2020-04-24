using Microsoft.AspNetCore.Builder;

namespace TopCase.OlivaTaxi.Api.Common.Middlewares
{
    public static class HttpExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseHttpExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HttpExceptionMiddleware>();
        }
    }
}