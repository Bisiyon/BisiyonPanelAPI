using BisiyonPanelAPI.Domain;

namespace BisiyonPanelAPI.Interface
{
    public interface IUnitOfWork
    {
        IRepositoryBase<T> Repository<T>() where T : BaseEntity;
        Task<int> SaveChangesAsync();

    }
}