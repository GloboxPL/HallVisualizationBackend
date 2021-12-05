using System.Collections.Generic;
using Backend.Models;
using MongoDB.Driver;

namespace Backend.Services
{
	public class DatabaseManager : IDatabaseManager
	{
		const string databaseName = "4g-flow";
		const string devicesCollectionName = "devices";
		readonly MongoClient client;
		readonly IMongoDatabase database;
		readonly IMongoCollection<Device> devicesCollection;

		public DatabaseManager(string connectionString)
		{
			client = new(connectionString);
			database = client.GetDatabase(databaseName);
			devicesCollection = database.GetCollection<Device>(devicesCollectionName);
		}

		public IEnumerable<Device> GetAllDevices(int hallId = 0)
		{
			var devices = devicesCollection.Find(x => x.HallId == hallId).ToEnumerable();
			return devices;
		}

		public Device GetDevice(string id)
		{
			var device = devicesCollection.Find(x => x.Id == id).First();
			return device;
		}
	}
}