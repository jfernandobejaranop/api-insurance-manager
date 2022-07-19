﻿using Domain.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCase.Interface
{
    public interface IPoliceWeb
    {
        List<Police> GetAll();
        List<Police> Get(string placa);
    }
}
