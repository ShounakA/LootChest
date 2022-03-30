using LootChestApi.Models;
using MongoDB.Driver;

namespace LootChestApi.Services;

public class ItemService
{
    private readonly IMongoCollection<Item> _itemsCollection;

    public ItemService(IOptions<LootChestDatabaseSettings> lootChestDatabaseSettings)
    {

    }
}