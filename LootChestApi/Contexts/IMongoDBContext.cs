using MongoDB.Driver;

namespace LootChestApi.Contexts;
public interface IMongoDBContext
{
    IClientSessionHandle Session { get; set; }

    IMongoCollection<T> GetCollection<T>(string name); 
}