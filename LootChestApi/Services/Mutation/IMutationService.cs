using MongoDB.Driver;
namespace LootChestApi.Services.Mutation;

interface IMutationService<T>
{
    public IMongoCollection<T> Collection {get;set;}
    public Task<T> CreateAsync(T newItem);
    public Task UpdateAsync(string id, T updatedItem);
    public Task RemoveAsync(string id);
}