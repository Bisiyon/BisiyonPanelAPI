using System.Linq.Expressions;
using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Domain;

namespace BisiyonPanelAPI.Interface
{
    public interface IServiceBase<T> where T : class, IEntity
    {
        Task<Result<List<T>>> GetAllAsync();
        Task<Result<List<T>>> GetAllAsync(Expression<Func<T, bool>> predicate);
        Task<Result<List<TDto>>> GetAllAsync<TDto>(DataFilterModelView model);
        Task<Result<List<T>>> GetAllAsync(DataFilterModelView model);
        Task<Result<T?>> GetByIdAsync(int id);
        Task<Result<T>> Insert(T entity);
        Task<Result<bool>> Update(T oldEntity, T newEntity);
        Task<Result<bool>> Delete(int id);
    }
}