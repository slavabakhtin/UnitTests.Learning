using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace TopCase.OlivaTaxi.Api.Common.Extensions
{
    public static class FirebaseAuthenticationExtensions
    {
        public static IServiceCollection AddFirebaseAuthentication(
            this IServiceCollection services, string firebaseProject)
        {
            return services.AddFirebaseAuthentication(firebaseProject, o => { });
        }

        public static IServiceCollection AddFirebaseAuthentication(
            this IServiceCollection services, string firebaseProject, Action<JwtBearerOptions> configureOptions)
        {
            var issuer = $"https://securetoken.google.com/{firebaseProject}";
            var metadataAddress = $"{issuer}/.well-known/openid-configuration";
            var configurationManager = new ConfigurationManager<OpenIdConnectConfiguration>(metadataAddress, new OpenIdConnectConfigurationRetriever());
            services
                .AddAuthentication(o =>
                {
                    o.DefaultAuthenticateScheme = "Bearer";
                    o.DefaultChallengeScheme = "Bearer";
                })
                .AddJwtBearer(o =>
                {
                    o.IncludeErrorDetails = true;
                    o.RefreshOnIssuerKeyNotFound = true;
                    o.MetadataAddress = metadataAddress;
                    o.ConfigurationManager = configurationManager;
                    o.Audience = firebaseProject;
                    configureOptions(o);
                });
            return services;
        }
    }
}