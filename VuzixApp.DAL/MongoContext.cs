using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuzixApp.DAL;

public class MongoContext
{
	private readonly MongoClient _client;
	public IMongoDatabase Database { get; }

	public MongoContext(string connectionString, string databaseName)
	{
		_client = new(connectionString);
		Database = _client.GetDatabase(databaseName);
	}
}