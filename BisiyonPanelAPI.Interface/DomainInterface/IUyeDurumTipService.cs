using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.View;
using BisiyonPanelAPI.View.BussinesObjects;

namespace BisiyonPanelAPI.Interface
{
    public interface IUyeDurumTipService : IServiceBase<UyeDurumTip>
    {
        Task<Result<List<UyeDurumTip>>> GetAll();
        Task<Result<UyeDurumTip>> GetById(int id);
        Task<Result<UyeDurumTip>> InsertAsync(UyeDurumTipBo entity);
        Task<Result<UyeDurumTip>> UpdateAsync(UyeDurumTipBo entity);
        Task<Result<bool>> DeleteAsync(int id);
    }
}