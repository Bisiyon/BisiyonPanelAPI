using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.View;
using BisiyonPanelAPI.View.BussinesObjects;

namespace BisiyonPanelAPI.Interface
{
    public interface IAidatGrupService : IServiceBase<AidatGrup>
    {
        Task<Result<List<AidatGrup>>> GetAll();
        Task<Result<AidatGrup>> GetById(int id);
        Task<Result<AidatGrup>> InsertAsync(AidatGrupBo entity);
        Task<Result<AidatGrup>> UpdateAsync(AidatGrupBo entity);
        Task<Result<bool>> DeleteAsync(int id);
    }
}