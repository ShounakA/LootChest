namespace LootChestApi.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Item
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id {get; set;}

    public string Name {get;set;} = null!;

    public string Description {get;set;} = null!;

    public string Location {get;set;} = null!;

    public string? ContainerId {get;set;}

    public int Quantity {get; set; }
    
    public IEnumerable<string> Tags {get; set; } = null!;
}
