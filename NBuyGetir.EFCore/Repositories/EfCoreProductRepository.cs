using NBuyGetir.Domain.Models;
using NBuyGetir.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBuyGetir.EFCore.Repositories
{
    public class EfCoreProductRepository : IProductRepository
    {
        public List<Product> List()
        {
            throw new NotImplementedException();
        }
    }
}
