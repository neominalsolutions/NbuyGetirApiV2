using NbuyGetir.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Infrastructure.Events.AspNetCoreDI
{
    public class DotNetDomainEventDispatcher : IDomainEventDispatcher
    {

        private readonly IServiceProvider _serviceProvider;

        public DotNetDomainEventDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task DispatchAsync<T>(params T[] events) where T : IDomainEvent
        {
            foreach (var @event in events)
            {
                if (@event == null)
                    throw new ArgumentNullException(nameof(@event), "Event can not be null.");

                var eventType = @event.GetType();
                var handlerType = typeof(IDomainEventHandler<>).MakeGenericType(eventType);
                var handler = 
                _serviceProvider.GetService(handlerType);

                if (handler == null)
                    return;

                await (Task)((dynamic)handler).HandleAsync(@event);
            }
        }
    }
}
