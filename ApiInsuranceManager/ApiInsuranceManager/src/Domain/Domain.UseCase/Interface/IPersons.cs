using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.DTO;

namespace Domain.UseCase.Interface
{
    public interface IPersons
    {
        List<Person> Create(List<Person> persons);
        List<Person> GetAll();
        List<Person> Get(string id);
    }
}
