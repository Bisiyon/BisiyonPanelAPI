using BisiyonPanelAPI.Domain;

namespace BisiyonPanelAPI.Interface
{
    public interface IUnitOfWork
    {
        IRepositoryBase<T> Repository<T>() where T : class, IEntity;
        Task<int> SaveChangesAsync();

    }
}