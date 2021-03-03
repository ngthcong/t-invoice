using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TInvoiceForm.Database.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        ICriteria<TEntity> CreateCriteria();
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(object id);
        int Count();
        long LongCount();
        TEntity Fetch(object id);
        List<TEntity> FetchAll();
        void Delete(ICriteria<TEntity> criteria);
        int Count(ICriteria<TEntity> criteria);
        long LongCount(ICriteria<TEntity> criteria);
        TEntity Fetch(ICriteria<TEntity> criteria);
        void Delete(Expression<Func<TEntity, bool>> predicate);
        int Count(Expression<Func<TEntity, bool>> predicate);
        long LongCount(Expression<Func<TEntity, bool>> predicate);
        TEntity Fetch(Expression<Func<TEntity, bool>> predicate);
        List<TEntity> FetchAll(ICriteria<TEntity> criteria);
        List<TEntity> FetchAll(int offset, int limit);
        List<TEntity> FetchAll(ICriteria<TEntity> criteria, int offset, int limit);
        List<TEntity> FetchAll(Expression<Func<TEntity, bool>> predicate);
    }
}
