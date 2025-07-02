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
                result.TotalRowCount = count;

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

        public async Task<Result<TDto?>> GetByIdAsync<TDto>(int id)
        {
            Result<TDto?> result = new();
            try
            {
                var data = await _dbSet.FindAsync(id);
                var dtoData = data.Adapt<TDto>();
                result.Data = dtoData;
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



        public async Task<Result<List<TDto>>> GetAllAsync<TDto>(Expression<Func<T, bool>>? predicate, Func<IQueryable<T>, IQueryable<T>> includeFunc = null)
        {
            Result<List<TDto>> result = new();
            try
            {
                IQueryable<T> query = _dbSet.AsQueryable();
                if (includeFunc != null)
                    query = includeFunc(query);
                if (predicate != null) query = query.Where(predicate);
                var dtoList = await query.ProjectToType<TDto>().ToListAsync();
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

        public async Task<Result<List<TDto>>> GetAllAsync<TDto>()
        {
            Result<List<TDto>> result = new();
            try
            {
                IQueryable<T> query = _dbSet.AsQueryable();
                var data = await query.ToListAsync();
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
        public async Task<T> Insert(T entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                return entity;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> Update(T newEntity)
        {
            try
            {
                var keyValues = GetPrimaryKeyValues(_context, newEntity);
                var trackedEntity = await _dbSet.FindAsync(keyValues);

                if (trackedEntity == null)
                    return false;

                _context.Entry(trackedEntity).CurrentValues.SetValues(newEntity);
                return true;
            }
            catch (Exception ex)
            {
                // loglama yapılabilir
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                T? entity = await _dbSet.FindAsync(id);
                if (entity is null)
                {
                    return false;
                }
                _dbSet.Entry(entity).State = EntityState.Deleted;
                return true;

            }
            catch (System.Exception ex)
            {
                return false;
            }
        }

        public async Task<T> Insert<TDto>(TDto entity)
        {
            try
            {
                var entityToInsert = entity.Adapt<T>();
                await _dbSet.AddAsync(entityToInsert);
                return entityToInsert;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public async Task<List<T>> BulkInsert<TDto>(List<TDto> entity)
        {
            List<T> result = new();
            try
            {
                var entityToInsert = entity.Adapt<List<T>>();
                await _dbSet.AddRangeAsync(entityToInsert);
                return entityToInsert;

            }
            catch (System.Exception ex)
            {
                return result;
            }
        }

        public async Task<bool> Update<TDto>(TDto newEntity)
        {
            try
            {
                var newDto = newEntity.Adapt<T>();
                var keyValues = GetPrimaryKeyValues(_context, newDto);
                var trackedEntity = await _dbSet.FindAsync(keyValues);

                if (trackedEntity == null)
                    return false;

                _context.Entry(trackedEntity).CurrentValues.SetValues(newDto);
                return true;
            }
            catch (Exception ex)
            {
                // loglama yapılabilir
                return false;
            }
        }

        private object[] GetPrimaryKeyValues<T>(DbContext context, T entity)
        {
            var entityType = context.Model.FindEntityType(typeof(T));
            var keyProperties = entityType?.FindPrimaryKey()?.Properties;

            if (keyProperties == null)
                throw new Exception($"Primary key not found for entity {typeof(T).Name}");

            var values = keyProperties
                .Select(p => typeof(T).GetProperty(p.Name)?.GetValue(entity))
                .ToArray();

            return values!;
        }
    }
}