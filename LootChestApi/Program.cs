using LootChestApi.Models;
namespace LootChestApi;

public class Program
{
    public static void Main(string[] args) 
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.Configure<LootChestDatabaseSettings>(builder.Configuration.GetSection("BookStoreDatabase"));
        builder.Services
            .AddGraphQLServer()
            .AddQueryType<Schema.Query>()
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