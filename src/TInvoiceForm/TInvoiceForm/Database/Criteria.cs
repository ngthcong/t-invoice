using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TInvoiceForm.Database.Interfaces;

namespace TInvoiceForm.Database
{
    public class Criteria<TEntity> : ICriteria<TEntity> where TEntity : class
    {
        private ParameterExpression _criteriaType;
        public BinaryExpression Condition
        {
            get;
            private set;
        }
        public ParameterExpression CriteriaType
        {
            get => _criteriaType ?? (_criteriaType = Expression.Parameter(typeof(TEntity)));
            private set => _criteriaType = _criteriaType ?? value;
        }
        public void Add(string Key, object Value)
        {
            var condition = (Expression.Equal(
                   Expression.Property(CriteriaType, Key),
                   Expression.Constant(Value)));
            Condition = Condition == null ? condition : Expression.AndAlso(Condition, condition);
        }
    }
}
