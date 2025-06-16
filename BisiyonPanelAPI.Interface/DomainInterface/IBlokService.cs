using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.View;

namespace BisiyonPanelAPI.Interface
{
    public interface IBlokService : IServiceBase<Blok>
    {
        List<KatDaireBilgisi> KatlariHesapla(int blokId);
        List<KatDaireBilgisi> HesaplaDaireNumaralari(List<KatDaireInput> katGirdileri);
        Result<bool> MeskenleriOlustur(List<KatDaireBilgisi> katDaireBilgileri);
    }
}