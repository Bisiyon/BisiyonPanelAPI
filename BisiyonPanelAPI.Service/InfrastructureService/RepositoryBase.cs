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
            Result<List<T>> result = new Result<List<T>>();
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

        public Task<Result<T>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<T>> Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> Update(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}