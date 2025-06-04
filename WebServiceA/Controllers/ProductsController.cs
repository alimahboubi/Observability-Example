using Microsoft.AspNetCore.Mvc;
using WebServiceA.Services;

namespace WebServiceA.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    public readonly ILogger<ProductsController> _logger;
    private readonly IProductService _productService;

    public ProductsController(ILogger<ProductsController> logger, IProductService productService)
    {
        _logger = logger;
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Fetching all products");
        var products = await _productService.GetProductsAsync(cancellationToken);
        return Ok(products);
    }
}