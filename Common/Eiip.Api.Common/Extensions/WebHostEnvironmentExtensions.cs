using System;
using Eiip.Common.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Eiip.Api.Common.Extensions
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