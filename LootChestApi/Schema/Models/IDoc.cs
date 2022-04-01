using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
interface IDoc
{ 
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get;set;}
}