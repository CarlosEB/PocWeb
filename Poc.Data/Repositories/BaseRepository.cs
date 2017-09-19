using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Poc.Data.Context;
using Poc.Domain.Interfaces;

namespace Poc.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly PocContext Db;
        protected IDbSet<TEntity> DbSet;

        public BaseRepository(PocContext bd)
        {
            Db = bd;
            DbSet = Db.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public virtual bool Create(TEntity obj)
        {
            DbSet.Add(obj);
            return true;
        }

        public TEntity Details(int id)
        {
            return DbSet.Find(id);
        }

        public virtual void Edit(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
        }

        public IEnumerable<TEntity> GetWhere(Expression<Func<TEntity, bool>> exp)
        {
            return DbSet.Where(exp).ToList();
        }

        public int GetTotal()
        {
            return DbSet.Count();
        }

        public int GetTotalWhere(Expression<Func<TEntity, bool>> exp)
        {
            return GetWhere(exp).Count();
        }

        public virtual void RemoveWhere(Expression<Func<TEntity, bool>> exp)
        {
            GetWhere(exp)
                .ToList()
                .ForEach(i => DbSet.Remove(i));
        }
    }
}