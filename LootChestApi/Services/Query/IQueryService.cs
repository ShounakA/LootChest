using MongoDB.Driver;
namespace LootChestApi.Services.Query;

interface IQueryService<T>
{
    public IMongoCollection<T> Collection {get; set;}
    public Task<List<T>> GetAsync();

    public Task<T?> GetAsync(string id);

}