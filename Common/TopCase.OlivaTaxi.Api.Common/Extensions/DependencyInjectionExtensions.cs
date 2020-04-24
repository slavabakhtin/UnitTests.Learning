using System;
using System.Net.Http;
using System.Text.Json.Serialization;
using AutoMapper;
using Google.Cloud.Diagnostics.AspNetCore;
using Google.Cloud.Diagnostics.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TopCase.OlivaTaxi.Api.Common.Exceptions;
using TopCase.OlivaTaxi.Api.Common.Middlewares;
using TopCase.OlivaTaxi.Common.Caching;

namespace TopCase.OlivaTaxi.Api.Common.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddCommonApiServices(this IServiceCollection services,
            IConfiguration configuration, IWebHostEnvironment hostEnvironment)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            services.AddMvc().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.JsonSerializerOptions.IgnoreNullValues = true;
            }).SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddSwaggerDocumentation();

            services.AddDistributedRedisCache(options =>
            {
                var redisSettings = configuration.GetSection(nameof(RedisSettings)).Get<RedisSettings>();
                options.Configuration = redisSettings.Configuration;
                options.InstanceName = redisSettings.InstanceName;
            });

            services.AddAutoMapper(x => {}, AppDomain.CurrentDomain.GetAssemblies());
            services.AddControllers();
            services.AddHealthChecks();
            services.AddSingleton<OlivaTaxiProblemDetailsFactory>();

            services.AddHttpContextAccessor();
            services.AddOlivaTaxiLogging(configuration, hostEnvironment.IsLocal());

            return services;
        }

        public static IServiceCollection AddOlivaTaxiLogging(this IServiceCollection services, IConfiguration configuration, bool isLocal)
        {
            var gcpProjectId = GooglePlatformHelper.GetProjectId(configuration);
            if (isLocal)
            {
                services.AddHttpClient("internalApiClient");

                services.AddLogging(loggingBuilder =>
                {
                    loggingBuilder.AddConfiguration(configuration.GetSection("Logging"));
                    loggingBuilder.AddConsole();
                    loggingBuilder.AddDebug();
                    loggingBuilder.AddEventSourceLogger();
                });

                return services;
            }

            services.AddGoogleExceptionLogging(options =>
            {
                options.ProjectId = gcpProjectId;
                options.ServiceName = GooglePlatformHelper.GetServiceName(configuration);
                options.Version = GooglePlatformHelper.GetVersion(configuration);
            });

            services.AddGoogleTrace(options => { options.ProjectId = gcpProjectId; });
            services.AddHttpClient("internalApiClient")
                .AddOutgoingGoogleTraceHandler();

            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConfiguration(configuration.GetSection("Logging"));
            });
            services.AddSingleton<ILoggerProvider>(sp => GoogleLoggerProvider.Create(sp, gcpProjectId));

            return services;
        }

        public static IServiceCollection AddOlivaTaxiContext<TContext>(this IServiceCollection services, IConfiguration configuration)
            where TContext : DbContext
        {
            services.AddScoped(typeof(DbMigrator<TContext>));
            services.AddDbContext<TContext>(opts => opts.UseSqlServer(configuration.GetConnectionString(typeof(TContext).Name)));

            return services;
        }

        public static IServiceCollection BuildInternalClient<T>(this IServiceCollection services, string baseUrlConfigKey, Func<HttpClient, T> clientFunc) where T : class
        {
            return services.AddSingleton(sp => BuildInternalClient(sp, baseUrlConfigKey, clientFunc));
        }

        public static IServiceCollection BuildInternalClient<T>(this IServiceCollection services, Func<HttpClient, T> clientFunc) where T : class
        {
            return services.AddSingleton(sp => BuildInternalClient(sp, $"InternalApis:{typeof(T).Name}", clientFunc));
        }

        private static T BuildInternalClient<T>(IServiceProvider sp, string baseUrlConfigKey, Func<HttpClient, T> clientFunc)
        {
            var httpClientFactory = sp.GetRequiredService<IHttpClientFactory>();
            var httpClient = httpClientFactory.CreateClient("internalApiClient");
            var configuration = sp.GetRequiredService<IConfiguration>();
            
            var baseUrl = configuration.GetValue<string>(baseUrlConfigKey);
            if (string.IsNullOrWhiteSpace(baseUrl))
            {
                throw new OlivaTaxiException($"Configuration error: \"{baseUrlConfigKey}\" for {typeof(T).Name} client is not set.");
            }

            httpClient.BaseAddress = new Uri(baseUrl);
            return clientFunc(httpClient);
        }

        public static IServiceCollection AddSingletonCache<TKey, TValue, TCache, TCacheRefresher>(this IServiceCollection services) 
            where TCache : RedisCache<TKey, TValue>
            where TCacheRefresher : CacheRefresher<TKey, TValue>
        {
            services.AddSingleton<TCache>();
            return services.AddSingleton<CacheRefresher<TKey, TValue>, TCacheRefresher>();
        }

        public static IServiceCollection AddSingletonCache<TKey, TValue, TCache>(this IServiceCollection services) 
            where TCache : RedisCache<TKey, TValue>
        {
            return services.AddSingletonCache<TKey, TValue, TCache, DoNothingCacheRefresher<TKey, TValue>>();
        }

        // public static IServiceCollection AddCloudPubSub(this IServiceCollection services)
        // {
        //     services.AddSingleton(typeof(MessageBusSubscriber<>));
        //     services.AddSingleton(typeof(IDeserializer<>), typeof(JsonDeserializer<>));
        //
        //     return services;
        // }
        //
        // public static IServiceCollection AddSubscriber<TItem, TMessageProcessor>(this IServiceCollection services)
        //     where TMessageProcessor : MessageProcessor<TItem>
        // {
        //     services.AddSingleton<MessageProcessor<TItem>, TMessageProcessor>();
        //
        //     return services;
        // }
    }
}
