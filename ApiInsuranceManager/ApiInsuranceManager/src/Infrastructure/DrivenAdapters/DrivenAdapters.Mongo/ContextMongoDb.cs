using MongoDB.Driver;
using Domain.Model.DTO;
using MongoDB.Bson;
using Microsoft.Extensions.Options;
using Domain.Model.Entities.MongoDB;
using Domain.Model.Entities.Gateway;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace DrivenAdapters.Mongo
{
    public class ContextMongoDb : IMongoEntityRepository
    {
        private readonly IMapper _mapper;
        private readonly ILogger<ContextMongoDb> _logger;
        private readonly IMongoCollection<CarShopWeb> _carShopWeb;
        private readonly IMongoCollection<FosygaWeb> _FosygaWeb;
        private readonly IMongoCollection<PoliceWeb> _PoliceWeb;
        public ContextMongoDb(IMongoDatabaseSettings settings, IMapper mapper, ILogger<ContextMongoDb> logger)
        {
            _logger = logger;
            _mapper = mapper;
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _carShopWeb = database.GetCollection<CarShopWeb>(settings.CarShopCollectionName);
            _FosygaWeb = database.GetCollection<FosygaWeb>(settings.FosygaCollectionName);
            _PoliceWeb = database.GetCollection<PoliceWeb>(settings.PoliceCollectionName);
        }

        public List<CarShop> GetAll()
        {
            var cars = _carShopWeb.Find(emp => true).ToList();
            return _mapper.Map<List<CarShop>>(cars);
        }

        public List<Fosyga> GetAllFosyga()
        {
            var person = _FosygaWeb.Find(emp => true).ToList();
            return _mapper.Map<List<Fosyga>>(person);
        }

        public List<Police> GetAllPolice()
        {
            var cars = _PoliceWeb.Find(emp => true).ToList();
            return _mapper.Map<List<Police>>(cars);
        }

        public List<Police> GetCarInfoPolice(string placa)
        {
            var filter = Builders<PoliceWeb>.Filter.Eq(c => c.Carriage, placa);
            var cars = _PoliceWeb.Find(filter).ToList();
            if (cars == null)
                return null;
            return _mapper.Map<List<Police>>(cars);
        }

        public List<CarShop> GetCarInformation(string placa)
        {
            var filter = Builders<CarShopWeb>.Filter.Eq(c => c.Carriage, placa);
            var cars = _carShopWeb.Find(filter).ToList();
            if (cars == null)
                return null;
            return _mapper.Map<List<CarShop>>(cars);
        }
        public List<Fosyga> GetPersonInfoFosyga(string id)
        {
            var filter = Builders<FosygaWeb>.Filter.Eq(c => c.Identification, id);
            var person = _FosygaWeb.Find(filter).ToList();
            if (person == null)
                return null;
            return _mapper.Map<List<Fosyga>>(person);
        }
    }
}
