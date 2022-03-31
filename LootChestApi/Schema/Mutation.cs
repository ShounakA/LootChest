
using LootChestApi.Services;
namespace LootChestApi.Schema;

public class Mutation
{
    private ItemService _itemService;
    private ChestService _chestService;
    public Mutation(ItemService itemService, ChestService chestService)
    { 
        _itemService = itemService;
        _chestService = chestService;
    }

    public async Task<Item> CreateItem(Item item)
    { 
        return await _itemService.CreateAsync(item);
    }

    public async Task<Chest> CreateChest(Chest chest)
    { 
         return await _chestService.CreateAsync(chest);
    }

}