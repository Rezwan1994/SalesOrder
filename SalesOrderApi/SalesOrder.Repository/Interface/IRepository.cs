using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrder.Repository.Interface
{
    public interface IRepository<TEntity>
     where TEntity : class
    {
        void Add(TEntity entity);
        void Remove(int id);
        void Remove(TEntity entityToDelete);
        void Edit(TEntity entityToUpdate);
        IQueryable<TEntity> Get();
        Task<TEntity?> GetById(int id);

        IQueryable<TEntity> Query(string sql);
    }
}
