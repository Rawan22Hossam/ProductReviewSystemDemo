using ProductReviewSystemDemo.GenericRepository;

namespace ProductReviewSystemDemo.UnitOfWork

{
        public interface IUnitOfWork : IDisposable
        {
            void Commit();
            void Rollback();
            IGenericRepository<T> GenericRepository<T>() where T : class;
        }
}

