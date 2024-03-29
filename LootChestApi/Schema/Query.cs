using HotChocolate.Data;
using LootChestApi.Services;
namespace LootChestApi.Schema;

public class Query
{

    [UseSorting]
    [UseFiltering]
    public IExecutable<Item> GetItems([Service] ItemService service)
    {
        return service.ItemCollection.AsExecutable();
    }

    [UseSorting]
    [UseFiltering]
    public IExecutable<Chest> GetChests([Service] ChestService service)
    {
        return service.ChestCollection.AsExecutable();
    }
}