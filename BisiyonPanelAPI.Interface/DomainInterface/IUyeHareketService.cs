using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.View;
using BisiyonPanelAPI.View.BussinesObjects;

namespace BisiyonPanelAPI.Interface
{
    public interface IUyeHareketService : IServiceBase<UyeHareket>
    {
        Task<Result<List<UyeHareket>>> GetAll();
        Task<Result<UyeHareket>> GetById(int id);
        Task<Result<UyeHareket>> InsertAsync(UyeHareketBo entity);
        Task<Result<UyeHareket>> UpdateAsync(UyeHareketBo entity);
        Task<Result<bool>> DeleteAsync(int id);
    }
}