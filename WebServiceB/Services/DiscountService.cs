using OpenTelemetry.Trace;

namespace WebServiceB.Services;

public class DiscountService :IDiscountService
{
    private readonly ILogger<DiscountService> _logger;
    private readonly Tracer _tracer;

    public DiscountService(ILogger<DiscountService> logger, Tracer tracer)
    {
        _logger = logger;
        _tracer = tracer;
    }

    public Task<decimal> GetActiveDiscountAsync(CancellationToken cancellationToken = default)
    {
        using var span = _tracer.StartActiveSpan("GetActiveDiscount");
        return Task.FromResult(0.1m); // Simulating a 10% discount
    }
}