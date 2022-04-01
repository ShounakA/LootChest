using LootChestApi.Contexts;
using LootChestApi.Schema.Models; 
using MongoDB.Driver;
namespace LootChestApi.Services.Query;
class ChestQueryService: Service, IQueryService<ChestQueryable>
{
    public IMongoCollection<ChestQueryable> Collection {get;set;}
    public ChestQueryService(IMongoDBContext context) : base (context)
    {
        Collection = _context.GetCollection<ChestQueryable>(typeof(ChestQueryable).Name.ToLower().Replace("queryable", ""));
    }

    public async Task<List<ChestQueryable>> GetAsync() =>
        await Collection.Find(_ => true).ToListAsync();

    public async Task<ChestQueryable?> GetAsync(string id) =>    
        await Collection.Find(x => x.Id == id).FirstOrDefaultAsync();
}