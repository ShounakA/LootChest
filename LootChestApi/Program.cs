using LootChestApi.Contexts;
using LootChestApi.Models;
using LootChestApi.Schema;
using LootChestApi.Schema.Models;
using LootChestApi.Services.Mutation;
using LootChestApi.Services.Query;
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

        builder.Services.AddSingleton<IMutationService<ItemMutable>, ItemMutationService>();
        builder.Services.AddSingleton<IMutationService<ChestMutable>, ChestMutationService>();
        builder.Services.AddSingleton<IQueryService<ItemQueryable>, ItemQueryService>();
        builder.Services.AddSingleton<IQueryService<ChestQueryable>, ChestQueryService>();
        
        builder.Services
               .AddGraphQLServer()
               .AddQueryType<Query>()
               .AddMutationType<Mutation>()
               .AddMongoDbFiltering()
               .AddMongoDbSorting();


        var app = builder.Build();

        //app.UseExceptionHandler();
        app.MapControllers();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapGraphQL();
        
        app.Run();
        
    }
}