using Catalog.Domain.DomainEvents.Product;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Catalog.Application.Features.DomainEventHandler
{
    public class ProductDomainEventHandler : INotificationHandler<ProductCreateEvent>
    {
        private readonly ILogger<ProductCreateEvent> logger;

        public ProductDomainEventHandler(ILogger<ProductCreateEvent> logger)
        {
            this.logger = logger;
        }

        public Task Handle(ProductCreateEvent notification, CancellationToken cancellationToken)
        {
            logger.LogInformation(JsonConvert.SerializeObject(notification));
            return Task.CompletedTask;
        }
    }
}
