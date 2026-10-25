using Catalog.Application.Contracts.EventBus;
using MassTransit;

namespace Catalog.Application.Features.DomainEventHandler
{
    public class EventBusRepository : IEventBusRepository
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public EventBusRepository(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }
        public async Task PublishAsync<T>(T Message, CancellationToken cancellationToken = default) where T : class
        {
            await _publishEndpoint.Publish<T>(Message, cancellationToken);
        }
    }
}
