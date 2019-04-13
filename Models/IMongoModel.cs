using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models
{
    public interface IMongoModel
    {
        [BsonRepresentation(BsonType.ObjectId)]
        string Id { get; set; }
    }
}