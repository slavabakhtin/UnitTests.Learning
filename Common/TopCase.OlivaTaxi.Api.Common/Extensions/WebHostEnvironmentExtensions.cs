using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using TopCase.OlivaTaxi.Common.Models;

namespace TopCase.OlivaTaxi.Api.Common.Extensions
{
    public static class WebHostEnvironmentExtensions
    {
        public static bool IsLocal(this IWebHostEnvironment webHostEnvironment)
        {
            return webHostEnvironment.IsEnvironment(AdditionalEnvironments.Local) ||
                   webHostEnvironment.EnvironmentName.Contains(AdditionalEnvironments.RemoteEnvPrefix, StringComparison.OrdinalIgnoreCase);
        }
    }
}