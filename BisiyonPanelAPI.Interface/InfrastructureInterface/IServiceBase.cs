using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Domain;

namespace BisiyonPanelAPI.Interface
{
    public interface IServiceBase<T> where T : BaseEntity
    {
        Task<Result<List<T>>> GetAllAsync();
        Task<Result<T>> GetAsync(int id);
        Task<Result<T>> Insert(T entity);
        Task<Result<bool>> Update(T entity);
        Task<Result<bool>> Delete(int id);
    }
}