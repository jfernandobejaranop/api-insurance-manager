using AutoMapper;
using AutoMapper.Data;
using credinet.comun.api;
using credinet.comun.api.Swagger.Extensions;
using credinet.exception.middleware;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using OpenTelemetry;
using ApiInsuranceManager.AppServices.Automapper;
using DrivenAdapters.SQL;
using Microsoft.EntityFrameworkCore;
using DrivenAdapters.Mongo;
using Microsoft.Extensions.Options;

namespace ApiInsuranceManager.AppServices
{
    public class Startup
    {

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        private ILogger<Startup> Logger { get; }
        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(option => option.EnableEndpointRouting = false).AddNewtonsoftJson().AddFluentValidation();
            services.AddCors(options =>
            {
                options.AddPolicy("cors", b => b.AllowAnyHeader().AllowAnyMethod().AllowCredentials());
            });

            services.AddRespuestaApiFactory();
            services.AddVersionedApiExplorer();

            services.AddDbContext<InsuranceContext>(o =>
            {
                o.UseSqlServer(Configuration["SQLConfigurationProvider:SistecreditoDbConstr"]);
            });

            services.Configure<MongoDatabaseSettings>(Configuration.GetSection(nameof(MongoDatabaseSettings)));
            services.AddSingleton<IMongoDatabaseSettings>(sp => sp.GetRequiredService<IOptions<MongoDatabaseSettings>>().Value);

            services.AddAutoMapper(typeof(EntityProfile));

            services.AgregarServicios();
            services.HabilitarVesionamiento();
            services.ConfigurarSwaggerConVersiones(Environment, PlatformServices.Default.Application.ApplicationBasePath, new string[] { "ApiInsuranceManager.AppServices.xml" });

            services.AddCustomOpenTelemetry(Configuration, Environment);
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApiVersionDescriptionProvider provider)
        {
            app.UseCors("cors");
            app.UseStaticFiles(); // For the wwwroot folder

            if (!env.IsProduction())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger((c) =>
                {
                    c.PreSerializeFilters.Add((swaggerDoc, httpRequest) => { swaggerDoc.Info.Description = httpRequest.Host.Value; });
                });
                app.UseSwaggerUI(
                options =>
                {
                    // build a swagger endpoint for each discovered API version
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"../swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    }
                    options.InjectStylesheet($"../swagger.{env.EnvironmentName}.css");
                });
            }
            else
            {
                app.UseHsts();
            }
            app.ConfigureExceptionHandler();
            app.UseHttpsRedirection();
            app.UseAmbienteHeaderMiddleware();
            app.UseOrigenHeaderMiddleware();
            app.UseMvc();
        }
    }
}