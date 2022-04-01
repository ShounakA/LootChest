using LootChestApi.Contexts; 
using LootChestApi.Schema.Models;
using MongoDB.Driver;
namespace LootChestApi.Services.Mutation;
class ItemMutationService : Service, IMutationService<ItemMutable>
{

    public IMongoCollection<ItemMutable> Collection {get;set;}
    public ItemMutationService(IMongoDBContext context) : base (context)
    {
        Collection = _context.GetCollection<ItemMutable>(typeof(ItemMutable).Name.ToLower().Replace("mutable", ""));
    }
    public async Task<ItemMutable> CreateAsync(ItemMutable newItem)
    { 
        await Collection.InsertOneAsync(newItem);
        return newItem;
    }

    public async Task UpdateAsync(string id, ItemMutable updatedItem) =>
        await Collection.ReplaceOneAsync(x => x.Id == id,updatedItem);

    public async Task RemoveAsync(string id) =>
        await Collection.DeleteOneAsync(x => x.Id == id);
}