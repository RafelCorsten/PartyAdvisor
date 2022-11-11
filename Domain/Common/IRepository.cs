using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        IQueryable<TEntity> GetQueryable();

        Task<TEntity> FindAsync(object key);

        Task AddAsync(TEntity entity);

        Task AddRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void UpdateRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
