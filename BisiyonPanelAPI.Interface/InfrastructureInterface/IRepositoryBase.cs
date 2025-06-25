using System.Linq.Expressions;
using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Domain;

namespace BisiyonPanelAPI.Interface
{
    public interface IRepositoryBase<T> where T : class, IEntity
    {
        Task<Result<List<T>>> GetAllAsync();
        Task<Result<List<T>>> GetAllAsync(Expression<Func<T, bool>> predicate);
        Task<Result<List<TDto>>> GetAllAsync<TDto>(Expression<Func<T, bool>>? predicate,Func<IQueryable<T>, IQueryable<T>> includeFunc = null);
        Task<Result<List<TDto>>> GetAllAsync<TDto>();
        Task<PagedResult<List<TDto>>> GetAllAsync<TDto>(DataFilterModelView model);
        Task<PagedResult<List<T>>> GetAllAsync(DataFilterModelView model);
        Task<Result<T?>> GetByIdAsync(int id);
        Task<Result<TDto?>> GetByIdAsync<TDto>(int id);
        Task<Result<T>> Insert(T entity);
        Task<Result<TDto>> Insert<TDto>(TDto entity);
        Task<Result<bool>> Update(T newEntity,T oldEntity);
        Task<Result<bool>> Update<TDto>(TDto newEntity,TDto oldEntity);
        Task<Result<bool>> Delete(int id);

    }
}