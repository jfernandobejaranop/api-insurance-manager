using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Domain.Model.Entities;
using Domain.Model.Entities.Gateway;
using Microsoft.Extensions.Logging;
using Domain.UseCase.Interface;
using Domain.Model.DTO;

namespace Domain.UseCase.Implements
{
    /// <summary>
    /// EntityEPS
    /// </summary>
    public class CarShopWeb : ICarShop
    {
        private readonly IMongoEntityRepository _repository;
        private readonly ILogger<CarShopWeb> _logger;

        /// <summary>
        /// build
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="repo"></param>
        public CarShopWeb(ILogger<CarShopWeb> logger, IMongoEntityRepository repo)
        {
            _logger = logger;
            _repository = repo;
        }

        public List<CarShop> Get(string placa)
        {
            var cars = _repository.GetCarInformation(placa);
            if (cars != null)
                return cars;
            throw new Exception("No se encontaron resultados para la busqueda");       
        }

        public List<CarShop> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
