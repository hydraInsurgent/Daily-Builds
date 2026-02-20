namespace ConceptLab.Logging.Var2_MultipleProviders;

/// <summary>
/// Variation 2 demo: contract for the service that demonstrates multiple providers (Console + Debug).
/// One log call is routed to both sinks; same Logging:LogLevel applies to both.
/// </summary>
public interface IDemoService
{
    void Run();
}
