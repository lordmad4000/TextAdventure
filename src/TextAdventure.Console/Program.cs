using Microsoft.Extensions.DependencyInjection;
using TextAdventure;
using TextAdventure.Core;
using TextAdventure.Infrastructure;

public class Program
{
    public static async Task Main(string[] args)
    {
        var services = RegisterServices();
        var gameLoop= services.GetRequiredService<GameLoop>();
        await gameLoop.Run();
    }
    static IServiceProvider RegisterServices()
    {
        var services = new ServiceCollection();
        services.AddSingleton<GameLoop>();
        services.AddCore();
        services.AddInfrastructure();

        return services.BuildServiceProvider();
    }

}