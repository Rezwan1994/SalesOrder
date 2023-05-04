using SalesOrder.Domain.DbContexts;
using SalesOrder.Repository.Implementation;
using SalesOrder.Repository.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrder.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly SalesOrderDbContext _dbContext;
        private bool _disposed;
        private readonly Hashtable _repositories;
        private IOrderRepository _orderRepository;

        public UnitOfWork(SalesOrderDbContext dbContext)
        {
            _dbContext = dbContext;
            _repositories = new Hashtable();
        }
        public virtual async Task<int> SaveChangesAsync()
        {
            int result = 0;
            try
            {
                result = await _dbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                
            }
            return result;
        }
        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                _repositories.Add(type, new Repository<TEntity>(_dbContext));
            }
            return (IRepository<TEntity>)_repositories[type];
        }
        //public IOrderRepository IOrderRepository
        //{
        //    get
        //    {
        //        if (_orderRepository == null)
        //        {
        //            this._orderRepository = new OrderRepository(_dbContext);
        //        }
        //        return _orderRepository;
        //    }
        //}
      
        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
           // Dispose(true);
            //GC.SuppressFinalize(this);
        }
    }
}
