using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Model.Entities.MongoDB
{
    public class CarShopWeb
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string SuccessfulReview { get; set; }
        public string Brand { get; set; }
        public string Carriage { get; set; }
        public string Line { get; set; }
        public string Model { get; set; }
    }
}
