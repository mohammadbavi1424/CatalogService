using Microsoft.EntityFrameworkCore;

namespace Catalog.Persistance.FluentApi.BaseTypeConfiguration
{
    public interface IBaseTypeConfiguration<T> : IEntityTypeConfiguration<T> where T : class
    {
    }
}
