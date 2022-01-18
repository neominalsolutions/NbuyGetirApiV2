using NbuyGetir.Core.Events;
using NBuyGetir.Domain.Events;
using NBuyGetir.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBuyGetir.Domain.Handlers
{
    public class StockInHandler : IDomainEventHandler<StockedIn>
    {
        private readonly IProductRepository _productRepository;

        public StockInHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task HandleAsync(StockedIn @event)
        {
            var products =  _productRepository.List();
        }
    }
}
