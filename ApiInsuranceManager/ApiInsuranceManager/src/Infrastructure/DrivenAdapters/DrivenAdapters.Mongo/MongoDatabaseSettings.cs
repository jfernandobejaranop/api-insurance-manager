using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivenAdapters.Mongo
{
    public class MongoDatabaseSettings : IMongoDatabaseSettings
    { 
        public string CarShopCollectionName { get; set; }
        public string FosygaCollectionName { get; set; }
        public string PoliceCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IMongoDatabaseSettings
    {
        public string CarShopCollectionName { get; set; }
        public string FosygaCollectionName { get; set; }
        public string PoliceCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
