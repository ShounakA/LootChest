using LootChestApi.Contexts; 
using LootChestApi.Schema.Models;
using MongoDB.Driver;
namespace LootChestApi.Services.Mutation;
class ChestMutationService : Service, IMutationService<ChestMutable>
{

    public IMongoCollection<ChestMutable> Collection {get;set;}
    public readonly IMongoCollection<ItemMutable> ItemCollection;
    public ChestMutationService(IMongoDBContext context)
    :base (context)
    {
        Collection = _context.GetCollection<ChestMutable>(typeof(ChestMutable).Name.ToLower().Replace("mutable", ""));
        ItemCollection = this._context.GetCollection<ItemMutable>(typeof(ItemMutable).Name.ToLower().Replace("mutable", ""));
    }
    public async Task<ChestMutable> CreateAsync(ChestMutable newChest)
    { 
        if (newChest.Items.Any()) await ItemCollection.InsertManyAsync(newChest.Items);
        await Collection.InsertOneAsync(newChest);
        if (newChest.Items.Any())
        {
            ((List<ItemMutable>)newChest.Items).ForEach(item => item.ContainerId = newChest.Id);
            foreach (var item in newChest.Items)
            {
                await ItemCollection.FindOneAndUpdateAsync(
                    Builders<ItemMutable>.Filter.Where(rec => rec.Id == item.Id), 
                    Builders<ItemMutable>.Update.Set(rec => rec.ContainerId, newChest.Id)
                );
            }
        }
        return newChest;
    }

    public async Task UpdateAsync(string id, ChestMutable updatedChest) =>
        await Collection.ReplaceOneAsync(x => x.Id == id,updatedChest);

    public async Task RemoveAsync(string id) =>
        await Collection.DeleteOneAsync(x => x.Id == id);
}