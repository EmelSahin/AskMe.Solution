using AskMe.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace AskMe.DataAccessLayer.Concrete.EntityFramework.Repository
{
    public abstract class EfGenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected Context.Entities _dbContext;

        public EfGenericRepository()
        {
            _dbContext = new Context.Entities();
        }

        public T Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(Add)} entity must not be null");
            }
            try
            {
                _dbContext.Set<T>().Add(entity);
                _dbContext.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }
        }

        public bool Remove(int id)
        {
            return Remove(Get(id));
        }

        public bool Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(Remove)} entity must not be null");
            }
            try
            {
                _dbContext.Set<T>().Remove(entity);
                return _dbContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be removed: {ex.Message}");
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }

        public T Get(int id)
        {
            var entity = _dbContext.Set<T>().Find(id);
            return entity;
        }

        public List<T> GetAll()
        {
            try
            {
                return _dbContext.Set<T>().AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public List<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return _dbContext.Set<T>().AsNoTracking().Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public T Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(Update)} entity must not be null");
            }
            try
            {
                _dbContext.Set<T>().AddOrUpdate(entity);
                _dbContext.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }
    }
}
