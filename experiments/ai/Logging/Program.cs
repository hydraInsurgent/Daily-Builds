using ConceptLab.Logging.Step2_ConsoleConfiguration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

// Step 2: Minimal host — Host -> ILoggerFactory -> Console provider (JSON).
// CreateDefaultBuilder loads appsettings.json and registers logging; we replace the default
// console with the JSON formatter so we see structured output and config-driven levels.
IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureLogging(builder =>
    {
        builder.ClearProviders();
        // Single provider: JSON console. Tells ILoggerFactory to route all log events to the console as JSON.
        builder.AddJsonConsole();
    })
    .ConfigureServices(services =>
    {
        services.AddSingleton<IDemoService, DemoService>();
    })
    .Build();

// Resolve and run the Step 2 demo. DI injects ILogger<DemoService> and ILoggerFactory;
// the category for ILogger<T> is derived from the type (ConceptLab.Logging.Step2_ConsoleConfiguration.DemoService).
IDemoService demo = host.Services.GetRequiredService<IDemoService>();
demo.Run();

// Flush so JSON log output is visible when running from tooling/scripts.
await Console.Out.FlushAsync();
await Console.Error.FlushAsync();
