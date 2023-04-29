using SalesOrder.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrder.Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync();
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;
        //IOrderRepository IOrderRepository { get; }

    }
}
