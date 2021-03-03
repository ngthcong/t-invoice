using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TInvoiceForm.Database.Interfaces;

namespace TInvoiceForm.Database
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbSet<TEntity> _dbSet;
        protected DbContext _db;
        public Repository(DbContext db)
        {
            _dbSet = db.Set<TEntity>();
            _db = db;
        }
        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }
        public int Count()
        {
            return _dbSet.Count();
        }
        public int Count(ICriteria<TEntity> criteria)
        {
            return _dbSet.Count(GetCriteriaFunc(criteria));
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Count(predicate);
        }

        public ICriteria<TEntity> CreateCriteria()
        {
            return new Criteria<TEntity>();
        }

        public void Delete(object id)
        {
            var entityToDelete = Fetch(id);
            if (entityToDelete != null)
            {
                _dbSet.Remove(entityToDelete);
            }
        }

        public void Delete(ICriteria<TEntity> criteria)
        {
            var entityToDelete = Fetch(criteria);
            if (entityToDelete != null)
            {
                _dbSet.Remove(entityToDelete);
            }
        }

        public void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            var entityToDelete = Fetch(predicate);
            if (entityToDelete != null)
            {
                _dbSet.Remove(entityToDelete);
            }
        }

        public TEntity Fetch(object id)
        {
            var entity = _dbSet.Find(id);
            return entity;
        }

        public TEntity Fetch(ICriteria<TEntity> criteria)
        {
            return _dbSet.Where(GetCriteriaFunc(criteria)).FirstOrDefault();
        }

        public TEntity Fetch(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public List<TEntity> FetchAll()
        {
            var criteria = CreateCriteria();
            return FetchAll(criteria);
        }

        public List<TEntity> FetchAll(ICriteria<TEntity> criteria)
        {
            return criteria.Condition == null
                ? _dbSet.ToList()
                : _dbSet.Where(GetCriteriaFunc(criteria)).ToList();
        }

        public List<TEntity> FetchAll(int offset, int limit)
        {
            return FetchAll(null, offset, limit);
        }

        public List<TEntity> FetchAll(ICriteria<TEntity> criteria, int offset, int limit)
        {
            return ((criteria == null || criteria.Condition == null) ?
                _dbSet.Skip(offset).Take(limit).ToList() :
                _dbSet.Where(GetCriteriaFunc(criteria)).Skip(offset).Take(limit).ToList());
        }

        public List<TEntity> FetchAll(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public long LongCount()
        {
            return _dbSet.LongCount();
        }

        public long LongCount(ICriteria<TEntity> criteria)
        {
            return _dbSet.LongCount(GetCriteriaFunc(criteria));
        }

        public long LongCount(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.LongCount(predicate);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        protected Expression<Func<TEntity, bool>> GetCriteriaFunc(ICriteria<TEntity> criteria)
        {
            return Expression.Lambda<Func<TEntity, bool>>(criteria.Condition, criteria.CriteriaType);
        }
    }
}
