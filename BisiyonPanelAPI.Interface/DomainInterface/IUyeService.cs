using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.View;
using BisiyonPanelAPI.View.BussinesObjects;
using BisiyonPanelAPI.View.UyeView.Response;

namespace BisiyonPanelAPI.Interface
{
    public interface IUyeService : IServiceBase<Uye>
    {
        Task<Result<List<Uye>>> GetAll();
        Task<Result<Uye>> GetById(int id);
        Task<Result<Uye>> InsertAsync(UyeBo entity);
        Task<Result<Uye>> UpdateAsync(UyeBo entity);
        Task<Result<bool>> DeleteAsync(int id);
        Task<Result<UyeBo>> CreateUye(UyeBo bo);
        Task<Result<List<MeskenUyeListView>>> GetUyeByMeskenId(int id);
    }
}