using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Domain.Model.Entities;
using Domain.Model.Entities.Gateway;
using Microsoft.Extensions.Logging;
using Domain.UseCase.Interface;
using Domain.Model.DTO;

namespace Domain.UseCase.Implements
{
    /// <summary>
    /// EntityEPS
    /// </summary>
    public class EntityEPS : IEntityEPS
    {
        private readonly ISqlEntityRepository _repository;
        private readonly ILogger<EntityEPS> _logger;

        /// <summary>
        /// build
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="repo"></param>
        public EntityEPS(ILogger<EntityEPS> logger, ISqlEntityRepository repo)
        {
            _logger = logger;
            _repository = repo;
        }

        /// <summary>
        /// GetAllEPS
        /// </summary>
        /// <returns>EPS list</returns>
        public Task<IList<Eps>> GetAllEPS()
        {
            try
            {
                return _repository.GetAllEPS();
            }
            catch (NullReferenceException ex)
            {
                throw;
            }
        }
    }
}
