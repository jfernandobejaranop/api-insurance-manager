using Domain.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Model.DTO;

namespace Domain.UseCase.Interface
{
    public interface ICarShop
    {
        List<CarShop> GetAll();
        List<CarShop> Get(string placa);
    }
}
