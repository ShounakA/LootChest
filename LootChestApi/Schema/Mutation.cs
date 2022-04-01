
using LootChestApi.Services.Mutation;
using LootChestApi.Schema.Models;

namespace LootChestApi.Schema;

class Mutation
{
    private IMutationService<ItemMutable> _itemService;
    private IMutationService<ChestMutable> _chestService;
    public Mutation(ItemMutationService itemService, ChestMutationService chestService)
    { 
        _itemService = itemService;
        _chestService = chestService;
    }

    public async Task<ItemMutable> Item(ItemMutable item)
    { 
        return await _itemService.CreateAsync(item);
    }

    public async Task<ChestMutable> Chest(ChestMutable chest)
    { 
         return await _chestService.CreateAsync(chest);
    }

}