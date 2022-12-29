using Microsoft.Extensions.DependencyInjection;
using System.Text.RegularExpressions;
using TextAdventure.Core;
using TextAdventure.Core.Models;
using TextAdventure.Core.Services;
using TextAdventure.Infrastructure;

await GameLoop();

static async Task GameLoop()
{
    var services = RegisterServices();
    var commandService = services.GetRequiredService<ICommandService>();
    //PrintInConsole(idac.InicializarAventura());
    bool repeat = true;
    var command = new Command("", "", new Adventure());
    do
    {
        var input = Console.ReadLine();
        if (String.IsNullOrEmpty(input)) 
            input = "";
        if (input.ToLower() == "exit")
        {
            Console.WriteLine(@"Exit? Press 'Y' to confirm");
            ConsoleKeyInfo readKey = Console.ReadKey();
            if (readKey.Key == ConsoleKey.Y)
                repeat = false;
        }
        else
        {
            command.TextInput= input;
            var commandResult = await commandService.ExecuteCommand(command);
            PrintInConsole(commandResult.TextOutput);
        }
    } while (repeat);
}

static void PrintInConsole(string text)
{
    text = text.Replace("<br>", System.Environment.NewLine);
    text = Regex.Replace(text, "<.*?>", String.Empty);
    Console.WriteLine(text);
}

static IServiceProvider RegisterServices()
{
    var services = new ServiceCollection();
    services.AddCore();
    services.AddInfrastructure();

    return services.BuildServiceProvider();    
}