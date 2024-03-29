using LootChestApi.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace LootChestApi.Contexts;
public class MongoDBContext : IMongoDBContext
{
    private IMongoDatabase _db { get; set; }
    private MongoClient _mongoClient { get; set; }
    public IClientSessionHandle Session { get; set; }
    public MongoDBContext(IOptions<LootChestDatabaseSettings> configuration)
    {
        _mongoClient = new MongoClient(configuration.Value.Connection);
        _db =_mongoClient.GetDatabase(configuration.Value.DatabaseName);
    }
    
    public IMongoCollection<T> GetCollection<T>(string name)
    {
           return _db.GetCollection<T>(name);
    }
}