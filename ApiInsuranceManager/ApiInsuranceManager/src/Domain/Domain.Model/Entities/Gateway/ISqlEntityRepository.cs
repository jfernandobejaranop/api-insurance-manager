using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.DTO;

namespace Domain.Model.Entities.Gateway
{
    public interface ISqlEntityRepository
    {
        Task<IList<Eps>> GetAllEPS();
        bool CreatePerson(List<Person> persons);
        List<Person> GetAllPerson();
        List<Person> GetPerson(string id);
        Person FindPerson(int id_Person);
        bool CreatePolicy(Policy policy);
        Int64 FindBaseValor(int Id_InsuranceType);
        List<Policy> GetAllPolicy();
        Policy GetPolicy(int id_Policy);
        List<Policy> GetPolicyXPerson(int id_person);
        bool CreateVehicle(Vehicle vehicle);
    }
}
