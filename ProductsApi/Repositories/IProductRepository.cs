using ProductsApi.Contracts.Data;

namespace ProductsApi.Repositories;

public interface IProductRepository
{
    Task<bool> CreateAsync(ProductDto product);
    Task<ProductDto?> GetAsync(Guid id);
    Task<IEnumerable<ProductDto>> GetAllAsync();
    Task<bool> UpdateAsync(ProductDto product);
    Task<bool> DeleteAsync(Guid id);
}