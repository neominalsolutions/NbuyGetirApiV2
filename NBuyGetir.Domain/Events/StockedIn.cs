using NbuyGetir.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBuyGetir.Domain.Events
{
    public class StockedIn: IDomainEvent
    {
        public int OldStock { get; private set; }
        public int NewStock { get; private set; }

        public string ProductId { get; private set; }


        public StockedIn(string productId, int oldStock, int newStock)
        {
            ProductId = productId;
            OldStock = OldStock;
            NewStock = newStock;
        }

    }
}
