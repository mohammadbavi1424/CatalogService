using Catalog.Domain.Entities;
using Catalog.Persistance.FluentApi.BaseTypeConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Catalog.Persistance.Context
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options):base(options)
        {
                
        }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var assembly = Assembly.GetAssembly(typeof(IBaseTypeConfiguration<>));
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }


    }
}
