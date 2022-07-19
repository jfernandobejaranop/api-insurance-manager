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
    public class FosygaWeb : IFosygaWeb
    {
        private readonly IMongoEntityRepository _repository;
        private readonly ILogger<FosygaWeb> _logger;

        /// <summary>
        /// build
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="repo"></param>
        public FosygaWeb(ILogger<FosygaWeb> logger, IMongoEntityRepository repo)
        {
            _logger = logger;
            _repository = repo;
        }

        public List<Fosyga> Get(string id)
        {
            var person = _repository.GetPersonInfoFosyga(id);
            if (person != null)
                return person;
            throw new Exception("No se encontaron resultados para la busqueda");
        }

        public List<Fosyga> GetAll()
        {
            return _repository.GetAllFosyga();
        }
    }
}
