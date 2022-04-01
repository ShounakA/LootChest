using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using HotChocolate.Types;

namespace LootChestApi.Schema.Models;
class Chest
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id {get; set;} = null!;
    public string Name {get;set;} = null!;

    public IEnumerable<string?> Tags {get; set; } = null!;

}

class ChestMutable
{ 
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id {get; set;} = null!;
    public string Name {get;set;} = null!;

    public IEnumerable<string?> Tags {get; set; } = null!;
    public string? Description {get;set;}
    public string? Location {get;set;}
    public IEnumerable<ItemMutable> Items {get;set;} = null!;
}

class ChestQueryable
{ 
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id {get; set;} = null!;
    public string Name {get;set;} = null!;

    public IEnumerable<string?> Tags {get; set; } = null!;
    public string? Description {get;set;}
    public string? Location {get;set;}
    public IEnumerable<ItemQueryable> Items {get;set;} = null!;
}