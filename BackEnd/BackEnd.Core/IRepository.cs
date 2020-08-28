using System;
using System.Linq;

namespace BackEnd.Core
{
    public interface IRepository<TEntity>
    {
        IQueryable<TEntity> All();

        TEntity Add(TEntity entity);

        TEntity Update(TEntity entity);

        int SaveChanges();
    }
}
