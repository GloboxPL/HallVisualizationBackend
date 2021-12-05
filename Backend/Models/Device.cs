using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Backend.Models
{
	[BsonIgnoreExtraElements]
	public class Device
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }
		[BsonElement("id")]
		public int CustomId { get; set; }
		[BsonElement("hallId")]
		public int HallId { get; set; }
		[BsonElement("symbol")]
		public string Symbol { get; set; }
		[BsonElement("shortName")]
		public string ShortName { get; set; }
		[BsonElement("fullName")]
		public string FullName { get; set; }
		[BsonElement("efficiency")]
		public int Efficiency { get; set; }
		[BsonElement("socket")]
		public string Socket { get; set; }
		[BsonElement("height")]
		public int Height { get; set; }
	}
}