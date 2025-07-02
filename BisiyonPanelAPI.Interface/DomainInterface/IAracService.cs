using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.View;
using BisiyonPanelAPI.View.BussinesObjects;

namespace BisiyonPanelAPI.Interface
{
    public interface IAracService : IServiceBase<Arac>
    {
        Task<Result<List<Arac>>> GetAll();
        Task<Result<Arac>> GetById(int id);
        Task<Result<Arac>> InsertAsync(AracBo entity);
        Task<Result<Arac>> UpdateAsync(AracBo entity);
        Task<Result<bool>> DeleteAsync(int id);
        Task<Result<AracHareket>> LogAracGirisCikisAsync(int aracId, int aracHareketTipId);
    }
}