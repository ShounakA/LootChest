
using LootChestApi.Contexts; 
using MongoDB.Driver;
abstract class Service
{

    protected readonly IMongoDBContext _context;    
    public Service(IMongoDBContext context)
    {
        _context = context;
    }
}