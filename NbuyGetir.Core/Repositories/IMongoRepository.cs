using NbuyGetir.Core.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Repositories
{
    /// <summary>
    /// MongoDb .Net Drive ile crud select operasyonları yapacağımız repository.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IMongoRepository<TEntity>: IReadOnlyRepository<TEntity>, IWriteOnlyRepository<TEntity> where TEntity:IAggregateRoot
    {
    }
}
