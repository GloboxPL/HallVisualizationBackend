using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using VuzixApp.Domain.Models;

namespace VuzixApp.DAL.DatabaseModels;

[BsonIgnoreExtraElements]
public class Device
{
    [BsonId] public ObjectId Id { get; set; }
    [BsonElement("id")] public int CustomId { get; set; }
    [BsonElement("hallId")] public int HallId { get; set; }
    [BsonElement("symbol")] public string Symbol { get; set; } = string.Empty;
    [BsonElement("shortName")] public string ShortName { get; set; } = string.Empty;
    [BsonElement("fullName")] public string FullName { get; set; } = string.Empty;
    [BsonElement("efficiency")] public int Efficiency { get; set; }
    [BsonElement("socket")] public string Socket { get; set; } = string.Empty;
    [BsonElement("height")] public int Height { get; set; }

    [BsonRepresentation(BsonType.String)]
    [BsonElement("status")]
    public DeviceStatus Status { get; set; } = DeviceStatus.Off;

    [BsonElement("statusDescription")] public string StatusDescription { get; set; } = string.Empty;
    [BsonElement("reservationIds")] public IEnumerable<ObjectId> ReservationIds { get; set; } = new List<ObjectId>();

    [BsonElement("technicalExaminationDate")]
    public DateTime TechnicalExaminationDate { get; set; }
    [BsonElement("model3d")] public string Model3D { get; set; }
}