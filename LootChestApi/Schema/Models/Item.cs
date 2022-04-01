using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace LootChestApi.Schema.Models;

class Item
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get;set;} = null!;
    public string Name {get;set;} = null!;
    public int Quantity {get; set; }
    public IEnumerable<string?> Tags {get; set; } = null!;
}

class ItemMutable
{ 
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get;set;} = null!;
    public string Name {get;set;} = null!;
    public int Quantity {get; set; }
    public IEnumerable<string?> Tags {get; set; } = null!;
    public string ContainerId {get;set;} = null!;
    public string? Description {get;set;}
    public string? Location {get;set;}
    

}

class ItemQueryable
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get;set;} = null!;
    public string Name {get;set;} = null!;
    public int Quantity {get; set; }
    public IEnumerable<string?> Tags {get; set; } = null!; 
    public string? ContainerId {get;set;}
    public string? Description {get;set;}
    public string? Location {get;set;}

}