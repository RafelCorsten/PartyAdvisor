using Microsoft.EntityFrameworkCore;

namespace Domain.Common
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; }

        Task<int> SaveChanges();

        void BeginTransaction();

        Task CommitTransactionAsync();

        Task RollbackTransactionAsync();

        Task<TResponse> ExecuteNewTransaction<TResponse>(Func<Task<TResponse>> function);
    }
}
