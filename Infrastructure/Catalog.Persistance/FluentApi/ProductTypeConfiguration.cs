using Catalog.Domain.Entities;
using Catalog.Persistance.FluentApi.BaseTypeConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Persistance.FluentApi
{
    public class ProductTypeConfiguration : IBaseTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.CategoryId).IsRequired();
            builder.Property(p => p.ShortDescription).HasMaxLength(200).IsRequired();
            builder.Property(p => p.LongDescription).HasMaxLength(2000);
            builder.OwnsOne(p => p.Price, price =>
            {
                price.Property(p => p.Amount).HasColumnName("Amount").HasPrecision(18,2).IsRequired();
                price.Property(p => p.Currency).HasColumnName("Currency").HasMaxLength(3).IsRequired();
            });
            builder.OwnsOne(p => p.SKU, sku =>
            {
                sku.Property(p => p.Value).HasColumnName("Sku").HasMaxLength(100).IsRequired();
            });

            builder.HasOne(p => p.Category)
                .WithMany(p  => p.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
