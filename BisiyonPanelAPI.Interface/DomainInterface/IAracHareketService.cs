using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.View;
using BisiyonPanelAPI.View.BussinesObjects;

namespace BisiyonPanelAPI.Interface
{
    public interface IAracHareketService : IServiceBase<AracHareket>
    {
        Task<Result<List<AracHareket>>> GetAll();
        Task<Result<AracHareket>> GetById(int id);
        Task<Result<AracHareket>> InsertAsync(AracHareketBo entity);
        Task<Result<AracHareket>> UpdateAsync(AracHareketBo entity);
        Task<Result<bool>> DeleteAsync(int id);
        Task<Result<AracHareket>> LogAracGirisCikisAsync(int aracId, int aracHareketTipId);
    }
}