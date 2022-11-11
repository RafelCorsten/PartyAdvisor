using Domain.Common;

namespace DataBase.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private protected readonly IUnitOfWork _unitOfWork;

        public Repository(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return this._unitOfWork.Context.Set<TEntity>();
        }

        public async Task<TEntity> FindAsync(object key)
        {
            return await this._unitOfWork.Context.Set<TEntity>().FindAsync(key);
        }

        public async Task AddAsync(TEntity entity)
        {
            await this._unitOfWork.Context.Set<TEntity>().AddAsync(entity);
        }

        public async Task AddRange(IEnumerable<TEntity> entities)
        {
            await this._unitOfWork.Context.Set<TEntity>().AddRangeAsync(entities);
        }

        public void Update(TEntity entity)
        {
            this._unitOfWork.Context.Set<TEntity>().Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            this._unitOfWork.Context.Set<TEntity>().UpdateRange(entities);
        }

        public void Remove(TEntity entity)
        {
            this._unitOfWork.Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            this._unitOfWork.Context.Set<TEntity>().RemoveRange(entities);
        }
    }
}
