using ConceptLab.Logging.Var1_ConsoleConfiguration;
using ConceptLab.Logging.Var2_MultipleProviders;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

// Variation selector: arg, then env, then interactive menu.
// F5/debugger: use launch.json "args": ["1"] or ["2"] so no ReadLine (avoids Debug Console input bugs).
// Scripting: LOGGING_VAR=2. Interactive: dotnet run then type 1 or 2 in the terminal.
string? variation = args.Length > 0 ? args[0].Trim() : Environment.GetEnvironmentVariable("LOGGING_VAR");

if (string.IsNullOrEmpty(variation))
{
    Console.WriteLine("Logging Lab — select which variation to run:");
    Console.WriteLine("  1 - Var 1: Console + configuration (ILogger, DI, appsettings Logging, JSON console)");
    Console.WriteLine("  2 - Var 2: Console + Debug — multiple providers (same log events to both sinks)");
    Console.Write("Enter 1 or 2: ");
    variation = Console.ReadLine()?.Trim();
}

if (variation == "2")
{
    // Var 2: Two providers — same log events go to both Console (JSON) and Debug output.
    IHost host = Host.CreateDefaultBuilder(args)
        .ConfigureLogging(builder =>
        {
            builder.ClearProviders();
            builder.AddJsonConsole();
            builder.AddDebug();
        })
        .ConfigureServices(services =>
        {
            services.AddSingleton<ConceptLab.Logging.Var2_MultipleProviders.IDemoService, ConceptLab.Logging.Var2_MultipleProviders.DemoService>();
        })
        .Build();

    host.Services.GetRequiredService<ConceptLab.Logging.Var2_MultipleProviders.IDemoService>().Run();
}
else if (variation == "1")
{
    // Var 1: Single provider (JSON Console); config-driven levels and categories.
    IHost host = Host.CreateDefaultBuilder(args)
        .ConfigureLogging(builder =>
        {
            builder.ClearProviders();
            builder.AddJsonConsole();
        })
        .ConfigureServices(services =>
        {
            services.AddSingleton<ConceptLab.Logging.Var1_ConsoleConfiguration.IDemoService, ConceptLab.Logging.Var1_ConsoleConfiguration.DemoService>();
        })
        .Build();

    var demo = host.Services.GetRequiredService<ConceptLab.Logging.Var1_ConsoleConfiguration.IDemoService>();
    demo.Run();
}
else
{
    Console.WriteLine("Unknown or missing variation. Use 1 or 2 (or set LOGGING_VAR for non-interactive run).");
}

await Console.Out.FlushAsync();
await Console.Error.FlushAsync();
