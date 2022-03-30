namespace LootChestApi.Models;

public class LootChestDatabaseSettings
{
    public const string SectionName = "LootChestDatabase";
    public string Connection { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;

}