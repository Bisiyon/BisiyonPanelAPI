using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.View;
using BisiyonPanelAPI.View.BussinesObjects;

namespace BisiyonPanelAPI.Interface
{
    public interface IPersonelTipService : IServiceBase<PersonelTip>
    { 
        Task<Result<List<PersonelTip>>> GetAll();
        Task<Result<PersonelTip>> GetById(int id);
        Task<Result<PersonelTip>> InsertAsync(PersonelTipBo entity);
        Task<Result<PersonelTip>> UpdateAsync(PersonelTipBo entity);
        Task<Result<bool>> DeleteAsync(int id);
    }
}