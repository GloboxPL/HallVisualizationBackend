using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using VuzixApp.Domain.Models;

namespace VuzixApp.DAL.DatabaseModels;

[BsonIgnoreExtraElements]
public class User
{
    [BsonId] public ObjectId Id { get; set; }
    [BsonElement("email")] public string Email { get; set; } = string.Empty;
    [BsonElement("name")] public string Name { get; set; } = string.Empty;
    [BsonElement("surname")] public string Surname { get; set; } = string.Empty;
    [BsonElement("password")] public string Password { get; set; } = string.Empty;

    [BsonRepresentation(BsonType.String)]
    [BsonElement("role")]
    public Role Role { get; set; } = Role.User;

    [BsonElement("profilePicture")] public string? ProfilePicture { get; set; }
}