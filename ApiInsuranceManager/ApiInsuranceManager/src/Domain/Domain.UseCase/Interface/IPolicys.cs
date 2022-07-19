using Domain.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCase.Interface
{
    public interface IPolicys
    {
        Policy Create(Policy policy);
        List<Policy> GetAll();
        Policy Get(int id_Policy);

        List<Policy> PolicyXPerson(string id);
    }
}
