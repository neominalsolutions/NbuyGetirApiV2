using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Events
{
    public interface IDomainEventHandler<in TEvent> where TEvent: IDomainEvent
    {
        /// <summary>
        /// Domain event handle async
        /// </summary>
        /// <param name="event"></param>
        Task HandleAsync(TEvent @event);
    }
}
