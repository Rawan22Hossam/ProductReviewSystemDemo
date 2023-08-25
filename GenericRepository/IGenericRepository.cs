using Microsoft.AspNetCore.Mvc;
using ProductReviewSystemDemo.DTO;
using ProductReviewSystemDemo.Models;
using System.Linq.Expressions;

namespace ProductReviewSystemDemo.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task Add(T enttity);
        Task Update(object id);
        Task Update(T entity);
        Task Delete(object id);
        Task Delete(Expression<Func<T, bool>> where);
        Task Delete(T entity);
        void DeleteRange(IQueryable<T> entities);
        Task<T> GetById(object id);
        Task<T> GetAsync(Expression<Func<T, bool>> where);
        T Get(Expression<Func<T, bool>> where);
        IQueryable<T> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeProperties);
        Task<IQueryable<T>> GetManyAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> GetMany(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties);
        Task AddRange(IEnumerable<T> list);
        Task RemoveRange(IEnumerable<T> list);
        Task UpdateRange(IEnumerable<T> list);
        void DetachAllEntities();
        void SaveChanges();
      //  Task Add(ReviewDTO reviewDTO);

        //void Insert(Product product);
    }
}
