using Domain.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Model.DTO;

namespace Domain.UseCase.Interface
{
    public interface IEntityEPS
    {
        Task<IList<Eps>> GetAllEPS();
    }
}
