using AutoMapper;
using Catalog.Application.Contracts.Products;
using Catalog.Application.DTOs.Product;
using Catalog.Domain.Entities;
using Catalog.Persistance.Context;
using GenericRepository.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Persistance.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly CatalogContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(CatalogContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddAsync(Product product, CancellationToken cancellationToken = default)
        {
            await _context.Product.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

        }

        public async Task DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var Item = (await GetByIdAsync(id, cancellationToken))
                .ConvertObject<Product, ProductDto>(_mapper);
            _context.Product.Remove(Item);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<ProductDto>> GetAsync(CancellationToken cancellationToken = default)
        => (await _context.Product.Include(c => c.Category).AsNoTracking().ToListAsync(cancellationToken))
                .ConvertListObject<ProductDto, Product>(_mapper);

        public async Task<IEnumerable<ProductDto>> GetByCategoryIdAsync(long CategoryId, CancellationToken cancellationToken = default)
         => (await _context.Product.Include(c => c.Category).AsNoTracking().Where(c => c.CategoryId == CategoryId)
            .ToListAsync(cancellationToken)).ConvertListObject<ProductDto, Product>(_mapper);

        public async Task<ProductDto> GetByIdAsync(long Id, CancellationToken cancellationToken = default)
         => (await _context.Product.AsNoTracking().FirstOrDefaultAsync(c => c.Id == Id, cancellationToken))
            .ConvertObject<ProductDto, Product>(_mapper);



        public async Task UpdateAsync(Product product, CancellationToken cancellationToken = default)
        {
            _context.Product.Update(product);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
