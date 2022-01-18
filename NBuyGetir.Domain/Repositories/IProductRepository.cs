using NBuyGetir.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBuyGetir.Domain.Repositories
{
    public interface IProductRepository
    {
        List<Product> List();
    }
}
