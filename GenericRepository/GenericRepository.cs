using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProductReviewSystemDemo.Context;
using ProductReviewSystemDemo.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Security.Cryptography;

namespace ProductReviewSystemDemo.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationContext _dbContext;
        private readonly DbSet<T> entities = null;
        public GenericRepository(ApplicationContext context)
        {
            _dbContext = context;
            entities = context.Set<T>();
        }

        public async Task Add(T enttity)
        {
            await _dbContext.Set<T>().AddAsync(enttity);
        }

        public async Task AddRange(IEnumerable<T> list)
        {
          _dbContext.Set<T>().AddRange(list);
        }

        public async Task Delete(object id)
        {
            var entity = _dbContext.Set<T>().Find(id);
            _dbContext.Set<T>().Remove(entity);
        }

        public async Task Delete(Expression<Func<T, bool>> where)
        {
            T entity = await _dbContext.Set<T>().FirstOrDefaultAsync(where);
            _dbContext.Set<T>().Remove(entity);
        }

        public async Task Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public void DeleteRange(IQueryable<T> entities)
        {
            _dbContext.Set<T>().RemoveRange(entities);
        }
        public async Task<T> GetAsync(Expression<Func<T, bool>> where)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(where);
        }
        public T Get(Expression<Func<T, bool>> where)
        {
            return _dbContext.Set<T>().FirstOrDefault(where);
        }
        public  IQueryable<T> GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query =  _dbContext.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return query;
        }
        public IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return query;
        }
        public async Task<T> GetById(object id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IQueryable<T>> GetManyAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return query.Where(where);
        }
        public IQueryable<T> GetMany(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return query.Where(where);
        }
        public async Task RemoveRange(IEnumerable<T> list)
        {
            _dbContext.Set<T>().RemoveRange(list);
        }
        public async Task Update(object id)
        {
            var entity = _dbContext.Set<T>().Find(id);
            _dbContext.Set<T>().Update(entity);
        }
        public async Task Update(T entity)
        {
            _dbContext.Attach(entity).State = EntityState.Modified;
        }
        public async Task UpdateRange(IEnumerable<T> list)
        {
            list.ToList().ForEach(item => _dbContext.Attach(item).State = EntityState.Modified);
        }
        public void DetachAllEntities()
        {
            var changedEntriesCopy = _dbContext.ChangeTracker.Entries()
                .ToList();

            foreach (var entry in changedEntriesCopy)
            {
                entry.State = EntityState.Detached;
            }
        }
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }


    }
}
