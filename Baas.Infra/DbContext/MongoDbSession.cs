using Baas.Domain.Entities;
using MongoDB.Driver;

namespace Baas.Infra.DbContext
{
    public class MongoDbSession
    {
        private readonly IMongoDatabase _database;

        public MongoDbSession()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            _database = client.GetDatabase("BaasDb");
        }

        public IMongoCollection<Account> Alunos => _database.GetCollection<Account>("Accounts");
    }
}
