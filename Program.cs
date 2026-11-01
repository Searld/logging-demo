using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

using ServiceProvider services = new ServiceCollection()
    .AddLogging(logging =>
    {
        logging.AddConfiguration(configuration.GetSection("Logging"));
        logging.AddConsole();                                         
        logging.AddDebug();                                           
    })
    .BuildServiceProvider();

ILogger<MyApp.Worker> logger = services.GetRequiredService<ILogger<MyApp.Worker>>();

WriteLogs();

Console.WriteLine("Измените appsettings.json, сохраните и нажмите Enter");
Console.ReadLine();
WriteLogs();

void WriteLogs()
{
    logger.LogDebug("Debug");
    logger.LogInformation("Information");
    logger.LogWarning("Warning");
}

namespace MyApp
{
    public class Worker { }
}
