using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Contracts.EventBus
{
    public interface IEventBusRepository
    {
        public Task PublishAsync<T>(T Message,CancellationToken cancellationToken = default) where T : class;
    }
}
