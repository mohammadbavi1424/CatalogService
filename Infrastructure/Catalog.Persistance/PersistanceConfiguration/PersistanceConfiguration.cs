using Catalog.Application.Contracts.EventBus;
using Catalog.Application.Contracts.Products;
using Catalog.Application.Features.DomainEventHandler;
using Catalog.Persistance.Context;
using Catalog.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Persistance.PersistanceConfiguration
{
    public static class PersistanceConfiguration
    {
        public static void AddConfigurationServices(this IServiceCollection services,
            string ConnectionString)
        {
            //AssembliesSetting assemblies = new();
            //assemblies.EntitiesAssemblies = [typeof(BaseEntity).Assembly];
            //assemblies.EntitiesConfigurationAssemblies =
            //    [typeof(IBaseTypeConfiguration<>).Assembly];

            //services.AddGenericConfigurations(setting, assemblies);

            services.AddDbContext<CatalogContext>(option =>
            {
                option.UseSqlServer(ConnectionString);
            });

            services.AddLifeCycle();

        }


        private static void AddLifeCycle(this IServiceCollection services)
        {
            services.AddScoped<IEventBusRepository,EventBusRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
        }

    }
}
