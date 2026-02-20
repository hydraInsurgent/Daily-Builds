using Microsoft.Extensions.Logging;

namespace ConceptLab.Logging.Var1_ConsoleConfiguration;

/// <summary>
/// Variation 1: Demonstrates ILogger&lt;T&gt; (category from type) and ILoggerFactory (explicit category).
/// Log level filtering is driven by appsettings.json "Logging:LogLevel".
/// </summary>
public sealed class DemoService : IDemoService
{
    private readonly ILogger<DemoService> _logger;
    private readonly ILoggerFactory _loggerFactory;

    public DemoService(ILogger<DemoService> logger, ILoggerFactory loggerFactory)
    {
        _logger = logger;
        _loggerFactory = loggerFactory;
    }

    public void Run()
    {
        // --- ILogger<T>: category is the full name of T (ConceptLab.Logging.Var1_ConsoleConfiguration.DemoService)
        //    Our config sets "ConceptLab.Logging.Var1_ConsoleConfiguration" to Debug, so we see Information and below for this namespace.
        _logger.LogTrace("Trace from ILogger<DemoService>");
        _logger.LogDebug("Debug from ILogger<DemoService>");
        _logger.LogInformation("Information from ILogger<DemoService>");
        _logger.LogWarning("Warning from ILogger<DemoService>");
        _logger.LogError("Error from ILogger<DemoService>");

        // --- ILoggerFactory: create a logger with an explicit category to show config per category.
        //    We use a category that has Trace in appsettings so we see one more level (Trace) here.
        ILogger explicitCategoryLogger = _loggerFactory.CreateLogger("ConceptLab.Logging.Var1_ConsoleConfiguration.ExplicitCategory");
        explicitCategoryLogger.LogTrace("Trace from ILoggerFactory-created logger (ExplicitCategory)");
        explicitCategoryLogger.LogDebug("Debug from ILoggerFactory-created logger (ExplicitCategory)");
    }
}
