using Microsoft.EntityFrameworkCore;
using ProductReviewSystemDemo.Context;
using ProductReviewSystemDemo.GenericRepository;

namespace ProductReviewSystemDemo.UnitOfWork
{
        public class UnitOfWork : IUnitOfWork, IDisposable
        {
            private readonly ApplicationContext _dbContext;
            private bool _disposed;
            public UnitOfWork(ApplicationContext dbContext)
            {
                _dbContext = dbContext;
            }
            public void Commit()
            {
                _dbContext.SaveChanges();
            }
            public void Rollback()
            {
                foreach (var entry in _dbContext.ChangeTracker.Entries())
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entry.State = EntityState.Detached;
                            break;
                    }
                }
            }
            public IGenericRepository<T> GenericRepository<T>() where T : class
            {
                return new GenericRepository<T>(_dbContext);
            }
            private bool disposed = false;
            protected virtual void Dispose(bool disposing)
            {
                if (!this.disposed)
                {
                    if (disposing)
                    {
                        _dbContext.Dispose();
                    }
                }
                this.disposed = true;
            }
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
        }
    }

