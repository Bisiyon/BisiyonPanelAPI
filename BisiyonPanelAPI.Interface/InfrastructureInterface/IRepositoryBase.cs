using System.Linq.Expressions;
using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Domain;

namespace BisiyonPanelAPI.Interface
{
    public interface IRepositoryBase<T> where T : class, IEntity
    {
        Task<Result<List<T>>> GetAllAsync();
        Task<Result<List<T>>> GetAllAsync(Expression<Func<T, bool>> predicate);
        Task<Result<List<TDto>>> GetAllAsync<TDto>(Expression<Func<T, bool>>? predicate, Func<IQueryable<T>, IQueryable<T>> includeFunc = null);
        Task<Result<List<TDto>>> GetAllAsync<TDto>();
        Task<PagedResult<List<TDto>>> GetAllAsync<TDto>(DataFilterModelView model);
        Task<PagedResult<List<T>>> GetAllAsync(DataFilterModelView model);
        Task<Result<T?>> GetByIdAsync(int id);
        Task<Result<TDto?>> GetByIdAsync<TDto>(int id);
        // Insert methods
        Task<T> Insert(T entity);
        Task<T> Insert<TDto>(TDto entity);
        Task<List<T>> BulkInsert<TDto>(List<TDto> entity);
        Task<bool> Update(T newEntity);
        Task<bool> Update<TDto>(TDto newEntity);
        Task<bool> Delete(int id);
        
    }
}