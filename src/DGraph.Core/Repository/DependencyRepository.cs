using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DGraph.Core.Configuration;
using DGraph.Core.Domain;
using MongoDB.Driver;

namespace DGraph.Core.Repository
{
    public class DependencyRepository : IDependencyRepository
    {
        private readonly MongoClient _mongoClient;
        private readonly IConfiguration _configuration;
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<Dependency> _collection;
        private readonly string _databaseName;

        public DependencyRepository(MongoClient mongoClient, IConfiguration configuration, string databaseName = "DGraph")
        {
            _mongoClient = mongoClient;
            _configuration = configuration;
            _database = _mongoClient.GetDatabase(databaseName);
            _collection = _database.GetCollection<Dependency>("Dependency");
            _databaseName = databaseName;
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
            DropDatabase();
        }

        public async void DropDatabase()
        {
            await _mongoClient.DropDatabaseAsync(_databaseName);
        }

        public IQueryable<Dependency> SearchDependecies()
        {
            return _collection.AsQueryable<Dependency>();
        }
    }
}
