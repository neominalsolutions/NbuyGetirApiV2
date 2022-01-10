using NbuyGetir.Core.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Repositories
{

    // ISP => Interface Seggreagation
  
    // EF yi hem read hem write işlemleri için kullanacağız.
    public interface IEFRepository<TEntity> : IReadOnlyRepository<TEntity>, IWriteOnlyRepository<TEntity> where TEntity: IAggregateRoot
    {
       

    }
}
