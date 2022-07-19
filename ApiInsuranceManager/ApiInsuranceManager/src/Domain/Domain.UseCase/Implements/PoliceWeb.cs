using Domain.Model.DTO;
using Domain.Model.Entities.Gateway;
using Domain.UseCase.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCase.Implements
{
    public class PoliceWeb : IPoliceWeb
    {
        private readonly IMongoEntityRepository _repository;
        private readonly ILogger<PoliceWeb> _logger;

        /// <summary>
        /// build
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="repo"></param>

        public PoliceWeb(ILogger<PoliceWeb> logger, IMongoEntityRepository repo)
        {
            _logger = logger;
            _repository = repo;
        }
        public List<Police> Get(string placa)
        {
            var cars = _repository.GetCarInfoPolice(placa);
            if (cars != null)
                return cars;
            throw new Exception("No se encontaron resultados para la busqueda");
        }

        public List<Police> GetAll()
        {
            return _repository.GetAllPolice();
        }
    }
}
