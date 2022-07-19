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
    /// <summary>
    /// Policys
    /// </summary>
    public class Policys : IPolicys
    {
        private readonly ISqlEntityRepository _repository;
        private readonly ILogger<Policys> _logger;

        /// <summary>
        /// build
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="repo"></param>
        /// 
        public Policys(ILogger<Policys> logger, ISqlEntityRepository repo)
        {
            _logger = logger;
            _repository = repo;
        }
        public Policy Create(Policy policy)
        {
            var person = FindPerson(policy.Id_Person);
            if (person != null)
            {
                long baseValor = _repository.FindBaseValor(policy.Id_Insurance_Type);

                if (baseValor >= 0)
                {
                    int age = (DateTime.Now - person.DateOfBirth).Days / 30 / 12;
                    policy.FinalCost = CostCalculate(age, baseValor);
                    policy.IsActive = true;
                    if (_repository.CreatePolicy(policy))
                        return policy;
                    else
                        return null;
                }
                else
                    throw new Exception("Poliza no existe");
            }
            else
                throw new Exception("Persona no existe");
        }

        public Int64 CostCalculate(int age, long baseValor)
        {
            if (age >= 18 && age <= 25)
                return baseValor + (baseValor * 2 / 100);
            if (age >= 26 && age <= 35)
                return baseValor + (baseValor * 3 / 100);
            if (age >= 36 && age <= 45)
                return baseValor + (baseValor * 4 / 100);
            if (age >= 45 && age <= 55)
                return baseValor + (baseValor * 5 / 100);
            if (age >= 55 && age <= 65)
                return baseValor + (baseValor * 6 / 100);
            if (age > 65)
                return baseValor + (baseValor * 10 / 100);

            return baseValor + (baseValor * 10 / 100);
        }

        public Person FindPerson(int id_Person)
        {
            var person = _repository.FindPerson(id_Person);
            if (person == null)
                return null;
            else
                return person;
        }

        public int AgeCaculate(Person person)
        {
            return (DateTime.Now - person.DateOfBirth).Days/30/12;
        }

        public List<Policy> GetAll()
        {
            return _repository.GetAllPolicy();
        }

        public Policy Get(int id_Policy)
        {
            var policy = _repository.GetPolicy(id_Policy);
            if (policy != null)
                return policy;
            else
                throw new Exception("Poliza no existe");      
        }

        public List<Policy> PolicyXPerson(string id)
        {
            var person = _repository.GetPerson(id);
            if (person != null)
            {
                var policys = _repository.GetPolicyXPerson(person[0].Id_Person);

                if (policys != null)
                    return policys;
                else
                    throw new Exception("No se encontraron polizas para el documento "+id);
            }
            else
                throw new Exception("Persona No existe"); 
        }
    }
}
