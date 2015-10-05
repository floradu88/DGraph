using System;
using System.Collections.Generic;
using System.Linq;
using DGraph.Core.Domain;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using DGraph.Core.Configuration;

namespace DGraph.Core.Repository
{
    public class DependencyRepository : IDependencyRepository
    {
        private readonly MongoClient _mongoClient;
        private readonly IConfiguration _configuration;
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<Dependency> _collection;

        public DependencyRepository(MongoClient mongoClient, IConfiguration configuration, string databaseName = "DGraph")
        {
            _mongoClient = mongoClient;
            _configuration = configuration;
            _database = _mongoClient.GetDatabase(databaseName);
            _collection = _database.GetCollection<Dependency>("Dependency");
        }

        public void Save(Dependency entry)
        {
            _collection.InsertOneAsync(entry);
        }

        public void BulkSave(IEnumerable<Dependency> entries)
        {
            _collection.InsertManyAsync(entries);
        }

        public void DeleteAll()
        {
            // This should be used for imports, to ensure the data directory doesn't bloat.
            DropDatabase("DGraph");
        }

        public async void DropDatabase(string databaseName = "DGraph")
        {
            await _mongoClient.DropDatabaseAsync(databaseName);
        }

        public void DeleteCollection(string collectionName = "DGraph")
        {
            _database.DropCollectionAsync(collectionName);
        }
    }
}
