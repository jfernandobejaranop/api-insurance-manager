using Domain.Model.DTO;
using Domain.Model.Entities.Gateway;
using Domain.UseCase.Interface;
using Microsoft.Extensions.Logging;

namespace Domain.UseCase.Implements
{
    /// <summary>
    /// Vehicle
    /// </summary>
    public class Vehicles : IVehicles
    {
        private readonly ISqlEntityRepository _repository;
        private readonly ILogger<Vehicles> _logger;

        /// <summary>
        /// build
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="repo"></param>
        /// 

        public Vehicles(ILogger<Vehicles> logger, ISqlEntityRepository repo)
        {
            _logger = logger;
            _repository = repo;
        }
        public Vehicle Create(Vehicle vehicle)
        {
            if (_repository.CreateVehicle(vehicle))
                return vehicle;
            else
                return null;
        }
    }
}
