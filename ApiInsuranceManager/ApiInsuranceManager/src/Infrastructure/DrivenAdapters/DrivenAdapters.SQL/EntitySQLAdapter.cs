using System;
using AutoMapper;
using System.Collections.Generic;
using Domain.Model.Entities;
using Domain.Model.Entities.Gateway;
using Microsoft.Extensions.Logging;
using DrivenAdapters.SQL;
using Domain.Model.DTO;
using System.Linq;
using System.Threading.Tasks;
using Domain.Model.Entities.SQL;

namespace DrivenAdapters.SQL
{
    public class EntitySQLAdapter : ISqlEntityRepository
    {
        private readonly IMapper _mapper;
        private readonly ILogger<EntitySQLAdapter> _logger;
        private InsuranceContext _context;

        /// <summary>
        /// build
        /// </summary>
        /// <param name="mapper"></param>
        public EntitySQLAdapter(IMapper mapper, ILogger<EntitySQLAdapter> logger, InsuranceContext context)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        /// </summary>
        /// <returns>Eps list</returns>
        public async Task<IList<Eps>> GetAllEPS()
        {
            _logger.LogInformation("Entro a GetAllEPS en: {time}", DateTimeOffset.Now);
            try
            {
                return _mapper.Map<List<Eps>>(_context.Eps.ToList());
            }
            catch (Exception ex)
            {
                throw new Exception("Error al momento de consultar", ex);
            }
        }

        /// </summary>
        /// <returns>Create Person</returns>
        public bool CreatePerson(List<Person> persons)
        {
            _logger.LogInformation("Entro a CreatePerson en: {time}", DateTimeOffset.Now);
            try
            {
                _context.Person.AddRange(_mapper.Map<List<TBL_PERSON>>(persons));
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Lo registros no fueron almacenados",ex);
            }
        }

        public List<Person> GetAllPerson()
        {
            _logger.LogInformation("Entro a GetAllPerson en: {time}", DateTimeOffset.Now);
            try
            {
                return _mapper.Map<List<Person>>(_context.Person.ToList());
            }
            catch (Exception ex)
            {
                throw new Exception("Error al momento de consultar", ex);
            }
        }

        public List<Person> GetPerson(string id)
        {
            _logger.LogInformation("Entro a GetAllPerson en: {time}", DateTimeOffset.Now);
            try
            {
                return _mapper.Map<List<Person>>(_context.Person.Where(p => p.Identification == id).ToList());
            }
            catch (Exception ex)
            {
                throw new Exception("Error al momento de consultar", ex);
            }
        }

        public Person FindPerson(int id_Person)
        {
            _logger.LogInformation("Entro a GetAllPerson en: {time}", DateTimeOffset.Now);
            try
            {
                return _mapper.Map<Person>(_context.Person.Where(p => p.IdPerson == id_Person).FirstOrDefault());
            }
            catch (Exception ex)
            {
                throw new Exception("Error al momento de consultar", ex);
            }
        }

        public bool CreatePolicy(Policy policy)
        {
            try
            {
                _context.Request.Add(_mapper.Map<TBL_REQUEST>(policy));
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al momento de registrar poliza", ex);
            }
        }

        public long FindBaseValor(int Id_InsuranceType)
        {
            try
            {
                return _context.InsuranceValues.Where(i => i.Id_Insurance_Type == Id_InsuranceType).Select(i => i.BaseValue).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al momento de consultar valores", ex);
            }
        }

        public List<Policy> GetAllPolicy()
        {
            try
            {
                return _mapper.Map<List<Policy>>(_context.Request.ToList());
            }
            catch (Exception ex)
            {
                throw new Exception("Error al momento de consultar", ex);
            }
        }

        public Policy GetPolicy(int id_Policy)
        {
            try
            {
                return _mapper.Map<Policy>(_context.Request.Where(r => r.Id_Request == id_Policy).FirstOrDefault());
            }
            catch (Exception ex)
            {
                throw new Exception("Error al momento de consultar", ex);
            }
        }

        public List<Policy> GetPolicyXPerson(int id_Person)
        {
            try
            {
                return _mapper.Map<List<Policy>>(_context.Request.Where(r => r.Id_Person == id_Person).ToList());
            }
            catch (Exception ex)
            {
                throw new Exception("Error al momento de consultar", ex);
            }
        }

        public bool CreateVehicle(Vehicle vehicle)
        {
            try
            {
                _context.Vehicle.Add(_mapper.Map<TBL_VEHICLE>(vehicle));
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al momento de registrar el vehículo", ex);
            }
        }
    }
}
