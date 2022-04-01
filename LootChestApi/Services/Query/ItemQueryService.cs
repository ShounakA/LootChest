using LootChestApi.Contexts;
using LootChestApi.Schema.Models; 
using MongoDB.Driver;
namespace LootChestApi.Services.Query;
class ItemQueryService : Service, IQueryService<ItemQueryable>
{

    public IMongoCollection<ItemQueryable> Collection {get;set;}
    public ItemQueryService(IMongoDBContext context) : base (context)
    {
        Collection = _context.GetCollection<ItemQueryable>(typeof(ItemQueryable).Name.ToLower().Replace("queryable", ""));
    }
    public async Task<List<ItemQueryable>> GetAsync() =>
        await Collection.Find(_ => true).ToListAsync();

    public async Task<ItemQueryable?> GetAsync(string id) =>
        await Collection.Find(x => x.Id == id).FirstOrDefaultAsync();
}