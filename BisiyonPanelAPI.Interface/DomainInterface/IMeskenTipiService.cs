using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.View;
using BisiyonPanelAPI.View.BussinesObjects;

namespace BisiyonPanelAPI.Interface
{
    public interface IMeskenTipiService : IServiceBase<MeskenTipi>
    {
        Task<Result<List<MeskenTipi>>> GetAll();
        Task<Result<MeskenTipi>> GetById(int id);
        Task<Result<MeskenTipi>> InsertAsync(MeskenTipiBo entity);
        Task<Result<MeskenTipi>> UpdateAsync(MeskenTipiBo entity);
        Task<Result<bool>> DeleteAsync(int id);
    }
}