using Microsoft.Extensions.Logging;

namespace ConceptLab.Logging.Var2_MultipleProviders;

/// <summary>
/// Variation 2: Logs a few lines so we see the same messages in both Console (JSON) and Debug output.
/// When running with a debugger attached, check the IDE's "Debug" / "Output" window for the Debug provider.
/// </summary>
public sealed class DemoService : IDemoService
{
    private readonly ILogger<DemoService> _logger;

    public DemoService(ILogger<DemoService> logger)
    {
        _logger = logger;
    }

    public void Run()
    {
        _logger.LogInformation("Var 2: this line appears in both Console (JSON) and Debug output.");
        _logger.LogWarning("Var 2: same event, two sinks — pipeline filters once, then forwards to every provider.");
    }
}
