using HotChocolate.Data;
using LootChestApi.Services.Query;
using LootChestApi.Schema.Models;
namespace LootChestApi.Schema;
 class Query
{
    private IQueryService<ItemQueryable> _itemService;
    private IQueryService<ChestQueryable> _chestService;
    public Query(ItemQueryService itemService, ChestQueryService chestService)
    {
        _itemService = itemService;
        _chestService = chestService;
    }

    [UseSorting]
    [UseFiltering]
    public IExecutable<ItemQueryable> GetItems()
    {
        return _itemService.Collection.AsExecutable();
    }

    [UseSorting]
    [UseFiltering]
    public IExecutable<ChestQueryable> GetChests()
    {
        return _chestService.Collection.AsExecutable();
    }

    public async Task<ChestQueryable?> GetChest([Argument("id")] string Id)
    {
        return await _chestService.GetAsync(Id);
    }

     
}