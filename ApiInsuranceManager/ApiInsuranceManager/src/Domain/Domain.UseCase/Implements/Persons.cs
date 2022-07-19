using Domain.Model.DTO;
using Domain.Model.Entities.Gateway;
using Domain.UseCase.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.UseCase.Implements
{
    /// <summary>
    /// Person
    /// </summary>
    public class Persons : IPersons
    {
        private readonly ISqlEntityRepository _repository;
        private readonly ILogger<Persons> _logger;

        /// <summary>
        /// build
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="repo"></param>
        /// 

        public Persons(ILogger<Persons> logger, ISqlEntityRepository repo)
        {
            _logger = logger;
            _repository = repo;
        }
        public List<Person> Create(List<Person> persons)
        {
            if (_repository.CreatePerson(persons))
                return persons;
            else
                return null;
        }

        public List<Person> Get(string id)
        {
            var person = _repository.GetPerson(id);
            if (person.Count > 0)
                return person;
            else
                throw new Exception("Persona no encontrada");
        }

        public List<Person> GetAll()
        {
            return _repository.GetAllPerson();
        } 
    }
}
