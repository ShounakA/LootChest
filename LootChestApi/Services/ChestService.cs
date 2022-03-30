using LootChestApi.Contexts; 
using LootChestApi.Models;
using MongoDB.Driver;


namespace LootChestApi.Services;
public class ChestService
{
    private readonly IMongoDBContext _context;
    public readonly IMongoCollection<Chest> ChestCollection;

    public ChestService(IMongoDBContext context)
    {
        _context = context;
        ChestCollection = _context.GetCollection<Chest>(typeof(Chest).Name.ToLower());
    }

    public async Task<List<Chest>> GetAsync() =>
        await ChestCollection.Find(_ => true).ToListAsync();

    public async Task<Chest?> GetAsync(string id) =>
        await ChestCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Chest newChest) =>
        await ChestCollection.InsertOneAsync(newChest);

    public async Task UpdateAsync(string id, Chest updatedChest) =>
        await ChestCollection.ReplaceOneAsync(x => x.Id == id, updatedChest);

    public async Task RemoveAsync(string id) =>
        await ChestCollection.DeleteOneAsync(x => x.Id == id);
}