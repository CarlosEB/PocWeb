using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Poc.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        bool Create(TEntity obj);
        TEntity Details(int id);
        void Edit(TEntity obj);
        IEnumerable<TEntity> GetWhere(Expression<Func<TEntity, bool>> exp);
        int GetTotal();
        int GetTotalWhere(Expression<Func<TEntity, bool>> exp);

        void RemoveWhere(Expression<Func<TEntity, bool>> exp);
    }
}
