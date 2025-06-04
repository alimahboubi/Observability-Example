using WebServiceA.Models;

namespace WebServiceA.Services;

public interface IProductService
{
    Task<List<Product>> GetProductsAsync(CancellationToken cancellationToken = default);
}