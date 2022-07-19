using AutoMapper;
using credinet.comun.api;
using Microsoft.Extensions.DependencyInjection;
using Domain.UseCase;
using DrivenAdapters.Mongo;
using Domain.Model.Entities.Gateway;
using Microsoft.Extensions.Logging;
using DrivenAdapters.SQL;
using Domain.UseCase.Interface;
using Domain.UseCase.Implements;

namespace ApiInsuranceManager.AppServices
{
    /// <summary>
    /// ConfigurationServices
    /// </summary>
    public static class ConfigurationServices
    {
        /// <summary>
        /// AgregarServicios
        /// </summary>
        /// <param name="services"></param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection AgregarServicios(this IServiceCollection services)
        {
            //service for type 'credinet.comun.api.RespuestaApiFactory'
            services.AddSingleton<IMensajesHelper, MensajesApiHelper>();
            services.AddScoped<IManageTestEntityUserCase,ManageTestEntityUserCase>();
            services.AddScoped<ISqlEntityRepository,EntitySQLAdapter>();
            services.AddScoped<IMongoEntityRepository, ContextMongoDb>();

            services.AddScoped<IEntityEPS, EntityEPS>();
            services.AddScoped<IPersons, Persons>();
            services.AddScoped<IPolicys, Policys>();
            services.AddScoped<IVehicles, Vehicles>();

            services.AddScoped<ICarShop, CarShopWeb>();
            services.AddScoped<IFosygaWeb, FosygaWeb>();
            services.AddScoped<IPoliceWeb, PoliceWeb>();

            //provider => new EntityAdapter(services.BuildServiceProvider().GetRequiredService<IMapper>())
            //REGISTRE ACÁ SUS SERVICIOS
            return services;
        }
    }
}
