using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Primitives;
using SC.Configuration.Provider.Mongo;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using System;
using System.Diagnostics;
using System.IO;

namespace ApiInsuranceManager.AppServices
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Activity.DefaultIdFormat = ActivityIdFormat.W3C;

            CreateHostBuilder(args)
                 .UseSerilog((hostBuilder, loggerConfiguration) =>
                 {
                     loggerConfiguration.ReadFrom.Configuration(hostBuilder.Configuration);
                     TrySetLogLevel(hostBuilder, loggerConfiguration);
                     ChangeToken.OnChange(() => hostBuilder.Configuration.GetReloadToken(), () => { TrySetLogLevel(hostBuilder, loggerConfiguration); });
                 })
                .Build().Run();
        }

        private static void TrySetLogLevel(HostBuilderContext hostBuilder, LoggerConfiguration loggerConfiguration)
        {
            try
            {
                var nivelLog = hostBuilder.Configuration.GetValue<string>($"{MongoConfigurationConstants.SettingsSectionName}:NivelLog");
                var levelSwitch = new LoggingLevelSwitch
                {
                    MinimumLevel = (LogEventLevel)Enum.Parse(typeof(LogEventLevel), nivelLog)
                };
                loggerConfiguration.MinimumLevel.ControlledBy(levelSwitch);
            }
            catch (Exception ex)
            {

            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
              .ConfigureAppConfiguration((context, config) =>
              {
                  IConfigurationRoot configurationRoot = config

                .Build();

                  //AddkeyValult(config, configurationRoot);
                 // AddMongoprovider(config, configurationRoot);

              })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void AddMongoprovider(IConfigurationBuilder config, IConfigurationRoot configurationRoot)
        {
            var settings = new MongoAppsettingsConfiguration();
            configurationRoot.GetSection("MongoConfigurationProvider").Bind(settings);
            config.AddMongoConfiguration(options =>
            {
                options.CollectionName = settings.CollectionName;
                options.ConnectionString = settings.ConnectionString;
                options.DatabaseName = settings.DatabaseName;
                options.ReloadOnChange = settings.ReloadOnChange;
            });
        }

        private static void AddkeyValult(IConfigurationBuilder config, IConfigurationRoot configurationRoot)
        {
            var settings = new AzureKeyVaultConfig();

            configurationRoot.GetSection(nameof(AzureKeyVaultConfig)).Bind(settings);
            ClientSecretCredential clientSecretCredential = new ClientSecretCredential(settings.TenantId, settings.AppId, settings.AppSecret);
            SecretClient client = new SecretClient(new Uri(settings.KeyVault), clientSecretCredential);
            config.AddAzureKeyVault(client, new AzureKeyVaultConfigurationOptions());
        }
    }
}