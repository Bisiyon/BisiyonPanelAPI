using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Infrastructure;
using BisiyonPanelAPI.Interface;
using Microsoft.EntityFrameworkCore;

namespace BisiyonPanelAPI.Service
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class, IEntity
    {

        private readonly BisiyonAppContext _context;
        private DbSet<T> _dbSet;

        public RepositoryBase(BisiyonAppContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<Result<List<T>>> GetAllAsync()
        {
            Result<List<T>> result = new();
            try
            {
                result.Data = await _dbSet.ToListAsync();
                result.State = ResultState.Successfull;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Exception = ex;
                result.State = ResultState.Fail;
            }
            return result;
        }

        public async Task<Result<T?>> GetByIdAsync(int id)
        {
            Result<T?> result = new();
            try
            {
                result.Data = await _dbSet.FindAsync(id);
                result.State = ResultState.Successfull;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Exception = ex;
                result.State = ResultState.Fail;
            }
            return result;
        }

        public async Task<Result<T>> Insert(T entity)
        {
            Result<T> result = new();
            try
            {
                await _dbSet.AddAsync(entity);
                int rst = await _context.SaveChangesAsync();
                result.Data = entity;
                result.State = rst > 0 ? ResultState.Successfull : ResultState.Fail;
            }
            catch (System.Exception ex)
            {
                result.Message = ex.Message;
                result.Exception = ex;
                result.State = ResultState.Fail;
            }
            return result;
        }

        public async Task<Result<bool>> Update(T oldEntity, T newEntity)
        {
            Result<bool> result = new();
            try
            {
                _context.Entry(oldEntity).CurrentValues.SetValues(newEntity);
                int rst = await _context.SaveChangesAsync();
                result.Data = rst > 0;
                result.State = rst > 0 ? ResultState.Successfull : ResultState.Fail;
            }
            catch (System.Exception ex)
            {
                result.Message = ex.Message;
                result.Exception = ex;
                result.State = ResultState.Fail;
                result.Data = false;
            }
            return result;
        }

        public async Task<Result<bool>> Delete(int id)
        {
            Result<bool> result = new();
            try
            {
                T? entity = await _dbSet.FindAsync(id);
                if (entity is null)
                {
                    result.Message = "Cannot find entity by id";
                    result.State = ResultState.Fail;
                    return result;
                }
                _dbSet.Entry(entity).State = EntityState.Deleted;
                int rst = await _context.SaveChangesAsync();
                result.Data = rst > 0;
                result.State = rst > 0 ? ResultState.Successfull : ResultState.Fail;
            }
            catch (System.Exception ex)
            {
                result.Message = ex.Message;
                result.Exception = ex;
                result.State = ResultState.Fail;
                result.Data = false;
            }
            return result;
        }
    }
}