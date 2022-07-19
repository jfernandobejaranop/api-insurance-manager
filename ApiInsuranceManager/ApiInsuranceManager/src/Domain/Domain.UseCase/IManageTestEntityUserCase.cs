using Domain.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.UseCase
{
    public interface IManageTestEntityUserCase
    {
        List<Entity> FindAll(Entity entity = null);
        Task<IList<Entity>> GetAllUsers(Entity entity = null);
    }
}