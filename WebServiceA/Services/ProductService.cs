using OpenTelemetry.Trace;
using WebServiceA.Models;

namespace WebServiceA.Services;

public class ProductService :IProductService
{
    private HttpClient _httpClient;
    private readonly Tracer _tracer;
    private ILogger<ProductService> _logger;

    public ProductService(HttpClient httpClient, ILogger<ProductService> logger, Tracer tracer)
    {
        _httpClient = httpClient;
        _logger = logger;
        _tracer = tracer;
    }

    public async Task<List<Product>> GetProductsAsync(CancellationToken cancellationToken = default)
    {
        using var span = _tracer.StartActiveSpan("GetProducts");
        _logger.LogInformation("Fetching products from external service");
        var response = await _httpClient.GetStringAsync("/discounts", cancellationToken);
        var discount = decimal.Parse(response);
        _logger.LogInformation("Fetched discount: {Discount}", discount);
        // Simulating product retrieval with a discount applied
        var products = new List<Product>
        {
            new Product { Id = 1, Name = "Product A", Price = 100 * (1 - discount) },
            new Product { Id = 2, Name = "Product B", Price = 200 * (1 - discount) }
        };
        return products;
    }
}