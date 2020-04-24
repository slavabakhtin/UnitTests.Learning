using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace TopCase.OlivaTaxi.Api.Common
{
    internal class ForwardedHeadersStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                app.UseForwardedHeaders();
                next(app);
            };
        }
    }
}