using MongoDB.Driver;

namespace VuzixApp.DAL;

public class MongoContext
{
    private const string DevicesCollectionName = "Devices";
    private const string ReservationsCollectionName = "Reservations";
    private const string UsersCollectionName = "Users";

    public MongoClient Client { get; }
    public IMongoDatabase Database { get; }

    public IMongoCollection<DatabaseModels.Device> Devices { get; }
    public IMongoCollection<DatabaseModels.Reservation> Reservations { get; }
    public IMongoCollection<DatabaseModels.User> Users { get; }

    public MongoContext(string connectionString, string databaseName)
    {
        Client = new MongoClient(connectionString);
        Database = Client.GetDatabase(databaseName);
        Devices = Database.GetCollection<DatabaseModels.Device>(DevicesCollectionName);
        Reservations = Database.GetCollection<DatabaseModels.Reservation>(ReservationsCollectionName);
        Users = Database.GetCollection<DatabaseModels.User>(UsersCollectionName);
    }
}