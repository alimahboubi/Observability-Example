using Microsoft.AspNetCore.Mvc;
using WebServiceB.Services;

namespace WebServiceB.Controllers;

[ApiController]
[Route("[controller]")]
public class DiscountsController : ControllerBase
{
    private readonly ILogger<DiscountsController> _logger;
    private readonly IDiscountService _discountService;

    public DiscountsController(ILogger<DiscountsController> logger, IDiscountService discountService)
    {
        _logger = logger;
        _discountService = discountService;
    }

    [HttpGet]
    public async Task<IActionResult> GetActiveDiscount(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Fetching active discount");
        var discount = await _discountService.GetActiveDiscountAsync(cancellationToken);
        return Ok(discount);
    }

}