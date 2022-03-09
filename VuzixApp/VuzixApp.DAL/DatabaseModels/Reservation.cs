using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace VuzixApp.DAL.DatabaseModels;

[BsonIgnoreExtraElements]
public class Reservation
{
    [BsonId] public ObjectId Id { get; set; }
    [BsonElement("start")] public DateTime Start { get; set; }
    [BsonElement("end")] public DateTime End { get; set; }
    [BsonElement("userId")] public ObjectId UserId { get; set; }
    [BsonElement("deviceId")] public ObjectId DeviceId { get; set; }
}