

using Catalog.Application.DTOs.Product;
using Catalog.Domain.Entities;

namespace Catalog.Application.Contracts.Products
{
    public interface IProductRepository
    {
        Task<ProductDto> GetByIdAsync(long Id, CancellationToken cancellationToken = default);
        Task<IEnumerable<ProductDto>> GetAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<ProductDto>> GetByCategoryIdAsync(long CategoryId, CancellationToken cancellationToken = default);
        Task AddAsync(Product product, CancellationToken cancellationToken = default);
        Task UpdateAsync(Product product, CancellationToken cancellationToken = default);
        Task DeleteAsync(long id, CancellationToken cancellationToken = default);

    }
}
