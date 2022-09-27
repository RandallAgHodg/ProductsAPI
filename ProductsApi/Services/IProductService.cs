using ProductsApi.Domain;

namespace ProductsApi.Services;

public interface IProductService
{
    Task<bool> CreateAsync(Product product);
    Task<Product?> GetAsync(Guid id);
    Task<IEnumerable<Product>> GetAllAsync(Guid userId);
    Task<bool> UpdateAsync(Product product);
    Task<bool> DeleteAsync(Guid id);
}