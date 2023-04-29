using Microsoft.EntityFrameworkCore;
using SalesOrder.Domain.DbContexts;
using SalesOrder.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrder.Repository.Implementation
{
    public class Repository<TEntity>
        : IRepository<TEntity>
        where TEntity : class
    {
        protected SalesOrderDbContext _dbContext;
        protected DbSet<TEntity> _dbSet;

        public Repository(SalesOrderDbContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<TEntity>();
        }
        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Edit(TEntity entityToUpdate)
        {
            if (_dbContext.Entry(entityToUpdate).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToUpdate);
            }
            _dbContext.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public IQueryable<TEntity> Get()
        {
            return _dbSet;
        }

        public async Task<TEntity?> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public IQueryable<TEntity> Query(string sql)
        {
            return _dbSet.FromSqlRaw(sql);

        }

        public void Remove(int id)
        {
            var entityToDelete = _dbSet.Find(id);
            Remove(entityToDelete);
        }

        public void Remove(TEntity entityToDelete)
        {
            if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }
    }
}
