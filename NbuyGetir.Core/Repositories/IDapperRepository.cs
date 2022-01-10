using NbuyGetir.Core.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Repositories
{
    /// <summary>
    /// Sadece Okuma işlemleri yapacağız.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IDapperRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : IAggregateRoot
    {

    }


}
