using System.Collections.Generic;
using Backend.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Backend.Services
{
    public class DatabaseManager : IDatabaseManager
    {
        const string databaseName = "4g-flow";
        const string devicesCollectionName = "Devices";

        MongoClient client;
        IMongoDatabase database;
        IMongoCollection<Device> devicesCollection;

        public DatabaseManager(string connectionString)
        {
            client = new(connectionString);
            database = client.GetDatabase(databaseName);
            devicesCollection = database.GetCollection<Device>(devicesCollectionName);
        }

        public IEnumerable<Device> GetAllDevices(int hallId = 0)
        {
            var enumarable = devicesCollection.Find(x => x.HallId == hallId).ToEnumerable();
            return enumarable;
        }

        public Device GetDevice(string id)
        {
            ObjectId objectId = new(id);
            var device = devicesCollection.Find(x => x.Id == objectId).First();
            return device;
        }
    }
}