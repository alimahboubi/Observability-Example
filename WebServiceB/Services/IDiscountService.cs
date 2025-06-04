namespace WebServiceB.Services;

public interface IDiscountService
{
    Task<decimal> GetActiveDiscountAsync(CancellationToken cancellationToken = default);
}