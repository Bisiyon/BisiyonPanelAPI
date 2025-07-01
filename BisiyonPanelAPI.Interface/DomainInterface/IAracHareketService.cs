using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.View;

namespace BisiyonPanelAPI.Interface
{
    public interface IAracHareketService : IServiceBase<AracHareket>
    {
        Task<Result<AracHareket>> LogAracGirisCikisAsync(int aracId, int aracHareketTipId);
    }
}