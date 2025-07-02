using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.View;
using BisiyonPanelAPI.View.BussinesObjects;

namespace BisiyonPanelAPI.Interface
{
    public interface IAidatService : IServiceBase<Aidat>
    {
        Task<Result<List<Aidat>>> GetAll();
        Task<Result<Aidat>> GetById(int id);
        Task<Result<Aidat>> InsertAsync(AidatBo entity);
        Task<Result<Aidat>> UpdateAsync(AidatBo entity);
        Task<Result<bool>> DeleteAsync(int id);
    }
}