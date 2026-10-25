using AutoMapper;
using Catalog.Application.Contracts.EventBus;
using Catalog.Application.Contracts.Products;
using Catalog.Application.DTOs.Product;
using Catalog.Application.Features.Product.Products.Commands.Requests;
using Catalog.Domain.Aggregates.ProductAggregate;
using GenericRepository.Utilities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Features.Product.Products.Commands.Handlers
{
    public class ProductCreateRequestHandler : IRequestHandler<ProductCreateRequest>
    {
        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepositroey;
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        private readonly IEventBusRepository eventBus;

        public ProductCreateRequestHandler(IProductRepository productRepository,
            ICategoryRepository categoryRepositroey,IMediator mediator,IMapper mapper,
            IEventBusRepository eventBus)
        {
            this.productRepository = productRepository;
            this.categoryRepositroey = categoryRepositroey;
            this.mediator = mediator;
            this.mapper = mapper;
            this.eventBus = eventBus;
        }

        public async Task Handle(ProductCreateRequest request, CancellationToken cancellationToken)
        {
            var category = await categoryRepositroey.GetByIdAsync(request.Product.CategoryId,cancellationToken);
            if (category == null)
            {
                throw new Exception($"Category not found");
            }
            var proAgg = new ProductAggregate(request.Product.ConvertObject<Domain.Entities.Product, ProductDto>(mapper));
            
            foreach(var item in proAgg.DomainEvent)
            {
                if(item is INotification notification)
                {
                    await mediator.Publish(item,cancellationToken);
                }
            }


            await eventBus.PublishAsync<ProductDto>(request.Product,cancellationToken);
            proAgg.ClearDomainEvent();

            await productRepository.AddAsync(proAgg.Product, cancellationToken);

        }
    }
}
