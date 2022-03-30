using LootChestApi.Contexts; 
using LootChestApi.Models;
using MongoDB.Driver;


namespace LootChestApi.Services;
public class ItemService
{
    private readonly IMongoDBContext _context;
    public readonly IMongoCollection<Item> ItemCollection;

    public ItemService(IMongoDBContext context)
    {
        _context = context;
        ItemCollection = _context.GetCollection<Item>(typeof(Item).Name.ToLower());
    }

    public async Task<List<Item>> GetAsync() =>
        await ItemCollection.Find(_ => true).ToListAsync();

    public async Task<Item?> GetAsync(string id) =>
        await ItemCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Item newItem) =>
        await ItemCollection.InsertOneAsync(newItem);

    public async Task UpdateAsync(string id, Item updatedItem) =>
        await ItemCollection.ReplaceOneAsync(x => x.Id == id, updatedItem);

    public async Task RemoveAsync(string id) =>
        await ItemCollection.DeleteOneAsync(x => x.Id == id);
}