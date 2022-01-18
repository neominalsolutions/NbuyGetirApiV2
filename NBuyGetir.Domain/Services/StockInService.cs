using NbuyGetir.Core.Events;
using NbuyGetir.Core.Services;
using NBuyGetir.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBuyGetir.Domain.Services
{
    public class StockInService: IDomainService
    {
        private readonly IDomainEventDispatcher _domainEventDispatcher;

        public StockInService(IDomainEventDispatcher domainEventDispatcher)
        {
            _domainEventDispatcher = domainEventDispatcher;
        }

       
        public async Task StockIn(string ProductId, int quantity)
        {
           await  _domainEventDispatcher.DispatchAsync(new StockedIn(productId: "1", oldStock: 10, newStock: 20));
        }
    }
}
