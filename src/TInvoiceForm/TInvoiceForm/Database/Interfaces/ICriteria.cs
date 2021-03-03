using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TInvoiceForm.Database.Interfaces
{
    /// <summary>
    /// The interface DataAccessLayer.ICriteria represents a query against a particular persistent class. 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface ICriteria<TEntity> where TEntity : class
    {
        BinaryExpression Condition { get; }
        ParameterExpression CriteriaType { get; }
        void Add(string Key, object Value);
    }
}
