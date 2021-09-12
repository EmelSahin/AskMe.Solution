using AskMe.DataAccessLayer.Abstract;
using AskMe.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AskMe.Business
{
    public abstract class GenericManager<T> : IGenericService<T> where T : class
    {
        private readonly IGenericRepository<T> _genericRepository;

        public GenericManager(IGenericRepository<T> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public T Add(T entity)
        {
            return _genericRepository.Add(entity);
        }

        public bool Remove(int id)
        {
            return _genericRepository.Remove(id);
        }

        public bool Remove(T entity)
        {
            return _genericRepository.Remove(entity);
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
                _genericRepository.Dispose();
            }
        }

        public T Get(int id)
        {
            return _genericRepository.Get(id);
        }

        public List<T> GetAll()
        {
            return _genericRepository.GetAll();
        }

        public List<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _genericRepository.GetAll(predicate);
        }

        public T Update(T entity)
        {
            return _genericRepository.Update(entity);
        }
    }
}
