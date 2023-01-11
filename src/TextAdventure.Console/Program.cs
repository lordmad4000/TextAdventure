using Microsoft.Extensions.DependencyInjection;
using TextAdventure;
using TextAdventure.Application;
using TextAdventure.Application.Configuration.AutoMapper;
using TextAdventure.Infrastructure;

public class Program
{
    static async Task Main(string[] args)
    {
        var services = RegisterServices();
        var gameLoop = services.GetRequiredService<GameLoop>();
        await gameLoop.Run();
    }
    static IServiceProvider RegisterServices()
    {
        var services = new ServiceCollection();
        services.AddSingleton<GameLoop>();
        services.AddApplication();
        services.AddInfrastructure();
        services.AddAutoMapper(typeof(ApplicationMappingProfile));
        AutoMapperConfig.RegisterMappings();

        return services.BuildServiceProvider();
    }

}