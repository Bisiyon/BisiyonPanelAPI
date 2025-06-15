using System.Linq.Expressions;
using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Infrastructure;
using BisiyonPanelAPI.Interface;
using Castle.DynamicLinqQueryBuilder;
using Mapster;
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
        public async Task<Result<List<T>>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            Result<List<T>> result = new();
            try
            {
                var query = _dbSet.AsQueryable();
                query = query.Where(predicate);
                result.Data = await query.ToListAsync();
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

        public async Task<PagedResult<List<TDto>>> GetAllAsync<TDto>(DataFilterModelView model)
        {
            PagedResult<List<TDto>> result = new();
            try
            {
                IQueryable<T> query = _dbSet.AsQueryable();

                if (model.FilterQuery != null)
                {
                    query = query.BuildQuery(model.FilterQuery);
                }

                if (!string.IsNullOrEmpty(model.OrderByField))
                {
                    query = model.OrderByIsAsc
                        ? query.OrderBy(x => EF.Property<object>(x, model.OrderByField))
                        : query.OrderByDescending(x => EF.Property<object>(x, model.OrderByField));
                }

                if (model.Page > 0 && model.PageSize > 0)
                {
                    query = query.Skip((model.Page - 1) * model.PageSize).Take(model.PageSize);
                }
                var data = await query.ToListAsync();
                var count = await query.CountAsync();
                result.TotalRowCount = count;
                var dtoList = data.Adapt<List<TDto>>();
                result.Data = dtoList;
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
        public async Task<PagedResult<List<T>>> GetAllAsync(DataFilterModelView model)
        {
            PagedResult<List<T>> result = new();
            try
            {
                IQueryable<T> query = _dbSet.AsQueryable();

                if (model.FilterQuery != null)
                {
                    query = query.BuildQuery(model.FilterQuery);
                }

                if (!string.IsNullOrEmpty(model.OrderByField))
                {
                    query = model.OrderByIsAsc
                        ? query.OrderBy(x => EF.Property<object>(x, model.OrderByField))
                        : query.OrderByDescending(x => EF.Property<object>(x, model.OrderByField));
                }

                if (model.Page > 0 && model.PageSize > 0)
                {
                    query = query.Skip((model.Page - 1) * model.PageSize).Take(model.PageSize);
                }
                var data = await query.ToListAsync();
                var count = await query.CountAsync();
                result.TotalRowCount= count;

                result.Data = data;
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
    }
}