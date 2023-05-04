using Microsoft.EntityFrameworkCore;
using SalesOrder.Repository.Interface;
using SalesOrder.Repository.UnitOfWork;
using SalesOrder.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrder.Service.Implementation
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TEntity> _repository;
        public BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = unitOfWork.Repository<TEntity>();
        }
        public async Task DeleteAsync(int id)
        {
            _repository.Remove(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _repository.Remove(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<TEntity> FindAsync(int id)
        {
            return await _repository.GetById(id);
        }

        public IQueryable<TEntity> Get()
        {
            return _repository.Get();
        }

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await _repository.Get().ToListAsync();
        }



        public async Task InsertAsync(TEntity entity, bool save = true)
        {
            try
            {
                _repository.Add(entity);
                if (save)
                {
                    await _unitOfWork.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {

            }

        }

        public async Task UpdateAsync(TEntity entity, bool save = true)
        {
            _repository.Edit(entity);
            try
            {
                if (save)
                {
                    await _unitOfWork.SaveChangesAsync();
                
                }
            }
            catch (Exception ex)
            {

            }

        }
    }
}
