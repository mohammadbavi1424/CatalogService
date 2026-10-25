using Catalog.Domain.Entities;
using Catalog.Persistance.FluentApi.BaseTypeConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Persistance.FluentApi
{
    public class CategoryTypeConfiguration : IBaseTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(500).IsRequired();
             
            builder.HasOne(p => p.Parent)
                .WithMany(p => p.ChildsCategory)
                .HasForeignKey(p => p.ParentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
