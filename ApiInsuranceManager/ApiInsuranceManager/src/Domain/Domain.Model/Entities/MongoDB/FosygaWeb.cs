using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Model.Entities.MongoDB
{
    public class FosygaWeb
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Identification { get; set; }
        public string IdentificationType { get; set; }
        public string EPS { get; set; }
        public string IsActive { get; set; }
    }
}
