using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Model.DTO;

namespace Domain.Model.Entities.Gateway
{
    /// <summary>
    /// ITestEntityRepository
    /// </summary>
    public interface IMongoEntityRepository
    {
        /// <summary>
        /// FindAll
        /// </summary>
        /// <returns>Entity list</returns>
        List<CarShop> GetAll();
        List<CarShop> GetCarInformation(string placa);

        List<Fosyga> GetAllFosyga();
        List<Fosyga> GetPersonInfoFosyga(string id);

        List<Police> GetAllPolice();
        List<Police> GetCarInfoPolice(string placa);
    }
}