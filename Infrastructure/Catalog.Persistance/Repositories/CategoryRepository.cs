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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CatalogContext _context;
        private readonly IMapper _mapper;

        public CategoryRepository(CatalogContext catalogContext, IMapper mapper)
        {
            _context = catalogContext;
            _mapper = mapper;
        }

        public async Task AddAsync(CategoryDto category, CancellationToken cancellationToken = default)
        {
            var Item = category.ConvertObject<Category, CategoryDto>(_mapper);
            await _context.Category.AddAsync(Item, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var Item = (await GetByIdAsync(id, cancellationToken))
                .ConvertObject<Category, CategoryDto>(_mapper);
            _context.Category.Remove(Item);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<CategoryDto>> GetAsync(CancellationToken cancellationToken = default)
         => (await _context.Category.ToListAsync(cancellationToken))
                .ConvertListObject<CategoryDto, Category>(_mapper);


        public async Task<CategoryDto> GetByIdAsync(long Id, CancellationToken cancellationToken = default)
         => (await _context.Category.FirstOrDefaultAsync(c => c.Id == Id, cancellationToken))
            .ConvertObject<CategoryDto, Category>(_mapper);


        public async Task UpdateAsync(CategoryDto category, CancellationToken cancellationToken = default)
        {
            var Item = category.ConvertObject<Category, CategoryDto>(_mapper);
            _context.Category.Update(Item);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
