using Domain.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCase.Interface
{
    public interface IVehicles
    {
        Vehicle Create(Vehicle vehicle);
    }
}
