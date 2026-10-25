using Catalog.Application.Contracts.EventBus;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Infrastructure.ExternalRepositories.EventBus
{
    public class EventBusRepository : IEventBusRepository
    {
        private readonly IPublishEndpoint _endpoint;

        public EventBusRepository(IPublishEndpoint endpoint)
        {
            _endpoint = endpoint;
        }

        public async Task PublishAsync<T>(T Message, CancellationToken cancellationToken = default) where T : class
        {
            await _endpoint.Publish<T>(Message, cancellationToken);
        }
    }
}
