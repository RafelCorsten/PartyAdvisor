using DataBase.Contexts;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace DataBase
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        public DbContext Context { get; private set; }

        private IDbContextTransaction _transaction;
        private bool _isDisposed;

        public UnitOfWork(PartyDbContext pdbDbContext)
        {
            this.Context = pdbDbContext;
        }

        public async Task<int> SaveChanges()
        {
            return await this.Context.SaveChangesAsync();
        }

        public void BeginTransaction()
        {
            this._transaction = this.Context.Database.BeginTransaction();
        }

        public async Task CommitTransactionAsync()
        {
            await this._transaction.CommitAsync();
        }

        public async Task RollbackTransactionAsync()
        {
            await this._transaction.RollbackAsync();
            this._transaction.Dispose();
        }

        public void Dispose()
        {
            this.Dispose(this._isDisposed);
            GC.SuppressFinalize(this);
        }

        public async Task<TResponse> ExecuteNewTransaction<TResponse>(Func<Task<TResponse>> function)
        {
            try
            {
                this.BeginTransaction();
                TResponse response = await function();
                await this.CommitTransactionAsync();
                return response;
            }
            catch
            {
                await this.RollbackTransactionAsync();
                throw;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._isDisposed && disposing)
            {
                this.Context.Dispose();
            }

            this._isDisposed = true;
        }
    }
}
