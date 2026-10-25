using Catalog.Application.DTOs.Product;

namespace Catalog.Application.Contracts.Products
{
    public interface ICategoryRepository
    {
        Task<CategoryDto> GetByIdAsync(long Id,CancellationToken cancellationToken = default);
        Task<IEnumerable<CategoryDto>> GetAsync(CancellationToken cancellationToken = default);
        Task AddAsync(CategoryDto category, CancellationToken cancellationToken = default);
        Task UpdateAsync(CategoryDto category, CancellationToken cancellationToken = default);
        Task DeleteAsync(long id, CancellationToken cancellationToken = default);

    }
}
