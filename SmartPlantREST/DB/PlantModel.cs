using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SmartPlantREST.DB
{
    public class PlantModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string MacAddress { get; set; }
        public int Watervalue { get; set; }
        public string TimeStamp { get; set; }
        public string Owner { get; set; }
        public int PlantType { get; set; }
    }
}
