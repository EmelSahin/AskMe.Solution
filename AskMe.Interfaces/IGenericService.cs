using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ServiceModel;

namespace AskMe.Interfaces
{
    public interface IGenericService<T> : IDisposable where T : class
    {
        [OperationContract]
        T Add(T entity);

        [OperationContract]
        T Get(int id);

        [OperationContract]
        List<T> GetAll();

        [OperationContract]
        List<T> GetAll(Expression<Func<T, bool>> predicate);

        [OperationContract]
        bool Remove(int id);

        [OperationContract]
        bool Remove(T entity);

        [OperationContract]
        T Update(T entity);
    }
}
