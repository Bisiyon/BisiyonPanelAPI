using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.View;
using BisiyonPanelAPI.View.BussinesObjects;

namespace BisiyonPanelAPI.Interface
{
    public interface IBlokService : IServiceBase<Blok>
    {
        List<KatDaireBilgisi> KatlariHesapla(int blokId);
        List<KatDaireBilgisi> HesaplaDaireNumaralari(List<KatDaireInput> katGirdileri);
        Result<bool> MeskenleriOlustur(List<KatDaireBilgisi> katDaireBilgileri);
        Task<Result<BlokBo>> CreateBlokWithMesken(CreateNewBlokWithMeskenRequestDto dto);
    }
}