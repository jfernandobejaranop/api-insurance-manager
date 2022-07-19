using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using System;
using System.Collections.Generic;

namespace OpenTelemetry
{
    public static class OpenTelemetryExtensions
    {
        public static IServiceCollection AddCustomOpenTelemetry(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
            var settings = new OpenTelemetryConfigurationSettings();
            configuration.GetSection("OpenTelemetryConfigurationSettings").Bind(settings);

            if (settings.IsEnabled)
            {
                services.AddOpenTelemetryTracing((builder) =>
                   {
                       builder.AddAspNetCoreInstrumentation(options =>
                       {
                           options.RecordException = true;
                       });

                       builder.SetResourceBuilder(ResourceBuilder.CreateDefault().AddService(environment.ApplicationName));

                       builder.AddSource("Azure.*");

                       builder.AddConsoleExporter();

                       if (settings.AddEntityFramework)
                       {
                           builder.AddEntityFrameworkCoreInstrumentation(options =>
                                  {
                                      options.SetDbStatementForText = true;
                                      options.SetDbStatementForStoredProcedure = true;
                                  });
                       }

                       builder.AddHttpClientInstrumentation();

                       builder.AddZipkinExporter(options =>
                       {
                           options.Endpoint = new Uri(settings.ZipEndPoint);
                       });
                   });
            }

            return services;
        }
    }
}