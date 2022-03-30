using LootChestApi.Contexts;
using LootChestApi.Models;
using LootChestApi.Schema;
using LootChestApi.Services;
namespace LootChestApi;

public class Program
{
    public static void Main(string[] args) 
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services
               .Configure<LootChestDatabaseSettings>(builder.Configuration.GetSection(LootChestDatabaseSettings.SectionName));
        builder.Services.AddSingleton<IMongoDBContext, MongoDBContext>();
        builder.Services.AddSingleton<ItemService>();
        builder.Services.AddSingleton<ChestService>();
        
        builder.Services
               .AddGraphQLServer()
               .AddQueryType<Query>()
               .AddFiltering()
               .AddSorting();


        var app = builder.Build();
        app.MapControllers();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapGraphQL();
        app.Run();
    }
}