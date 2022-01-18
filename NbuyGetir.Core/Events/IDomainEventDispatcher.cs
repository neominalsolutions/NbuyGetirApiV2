using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Events
{
    public interface IDomainEventDispatcher
    {
        Task DispatchAsync<T>(params T[] events) where T : IDomainEvent;
    }
}
