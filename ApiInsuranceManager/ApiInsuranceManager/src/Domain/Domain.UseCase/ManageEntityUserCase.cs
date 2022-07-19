using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Domain.Model.Entities;
using Domain.Model.Entities.Gateway;
using Microsoft.Extensions.Logging;

namespace Domain.UseCase
{
    /// <summary>
    /// ManageTestEntityUserCase
    /// </summary>
    public class ManageTestEntityUserCase : IManageTestEntityUserCase
    {
        private readonly IMongoEntityRepository testEntityRepository;
        private readonly ILogger<ManageTestEntityUserCase> _logger;

        public List<Entity> FindAll(Entity entity = null)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Entity>> GetAllUsers(Entity entity = null)
        {
            throw new NotImplementedException();
        }

        ///// <summary>
        ///// build
        ///// </summary>
        ///// <param name="testEntityRepository"></param>
        //public ManageTestEntityUserCase(IMongoEntityRepository testEntityRepository, ILogger<ManageTestEntityUserCase> logger)
        //{
        //    this.testEntityRepository = testEntityRepository;
        //    _logger = logger;
        //    _logger.LogInformation("Entro al use case en: {time}", DateTimeOffset.Now);
        //}

        //public List<Entity> FindAll(Entity entity = null)
        //{
        //    return testEntityRepository.FindAll(entity);
        //    //throw new NotImplementedException();
        //}

        ///// <summary>
        ///// GetAllUsers
        ///// </summary>
        ///// <returns>Entity list</returns>
        //public async Task<IList<Entity>> GetAllUsers(Entity entity = null)
        //{
        //    return testEntityRepository.FindAll(entity);
        //}
    }
}
