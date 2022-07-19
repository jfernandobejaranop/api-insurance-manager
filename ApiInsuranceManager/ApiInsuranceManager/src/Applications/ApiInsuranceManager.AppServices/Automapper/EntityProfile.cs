using AutoMapper;
using Domain.Model.DTO;
using Domain.Model.Entities;
using Domain.Model.Entities.MongoDB;
using Domain.Model.Entities.SQL;

namespace ApiInsuranceManager.AppServices.Automapper
{
    /// <summary>
    /// EntityProfile
    /// </summary>
    public class EntityProfile : Profile
    {
        public EntityProfile()
        {
            CreateMap<TBL_EPS, Eps>();

            CreateMap<Person, TBL_PERSON>();
            CreateMap<TBL_PERSON, Person>();

            CreateMap<Policy, TBL_REQUEST>();
            CreateMap<TBL_REQUEST, Policy>();

            CreateMap<TBL_VEHICLE, Vehicle>();
            CreateMap<Vehicle, TBL_VEHICLE>();

            CreateMap<CarShopWeb, CarShop>();
            CreateMap<CarShop, CarShopWeb>();

            CreateMap<Fosyga, FosygaWeb>();
            CreateMap<FosygaWeb, Fosyga>();

            CreateMap<PoliceWeb, Police>();
            CreateMap<Police, PoliceWeb>();
        }
    }
}
