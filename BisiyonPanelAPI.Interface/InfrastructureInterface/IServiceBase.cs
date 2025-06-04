using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Domain;

namespace BisiyonPanelAPI.Interface
{
    public interface IServiceBase<T> where T : class, IEntity
    {
        Task<Result<List<T>>> GetAllAsync();
        Task<Result<T?>> GetByIdAsync(int id);
        Task<Result<T>> Insert(T entity);
        Task<Result<bool>> Update(T oldEntity, T newEntity);
        Task<Result<bool>> Delete(int id);
    }
}