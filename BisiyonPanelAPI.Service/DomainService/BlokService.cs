using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Infrastructure;
using BisiyonPanelAPI.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BisiyonPanelAPI.Service
{
    public class BlokService : ServiceBase<Blok>, IBlokService
    {
        private readonly BisiyonMainContext _mainContext;
        public BlokService(IUnitOfWork unitOfWork, BisiyonMainContext mainContext) : base(unitOfWork)
        {
            _mainContext = mainContext;
        }


        public List<KatDaireBilgisi> KatlariHesapla(int blokId)
        {
            var entity = _mainContext.Blok.FirstOrDefault(x => x.Id == blokId);

            if (entity == null)
                return new List<KatDaireBilgisi>();

            var katBilgileri = new List<KatDaireBilgisi>();
            int daireNo = 1;
            int kalanDaire = entity.ToplamDaireSayisi;

            var tip = _mainContext.MeskenTipi.FirstOrDefault(x => x.Id == entity.BlokTipId);

            for (int i = 0; i < entity.ToplamKatSayisi && kalanDaire > 0; i++)
            {
                int mevcutKat = entity.KatBaslangicKati + i;
                string katAdi = mevcutKat == 0 ? "Zemin" : mevcutKat.ToString();

                if (katAdi != "Zemin")
                {
                    katAdi = tip.Kod + katAdi;
                }

                int buKatDaireSayisi = Math.Min(entity.VarsayilanKattakiDaireSayisi, kalanDaire);

                var daireler = new List<int>();
                for (int j = 0; j < buKatDaireSayisi; j++)
                {
                    daireler.Add(daireNo++);
                }

                kalanDaire -= buKatDaireSayisi;

                katBilgileri.Add(new KatDaireBilgisi
                {
                    Renk = tip.Renk,
                    KatAdi = katAdi,
                    DaireSayisi = buKatDaireSayisi,
                    DaireNumaralari = daireler
                });
            }

            return katBilgileri;
        }

        public List<KatDaireBilgisi> HesaplaDaireNumaralari(List<KatDaireInput> katGirdileri)
        {
            var katBilgileri = new List<KatDaireBilgisi>();
            int daireNo = 1;

            foreach (var kat in katGirdileri)
            {
                var daireler = new List<int>();

                for (int j = 0; j < kat.DaireSayisi; j++)
                {
                    daireler.Add(daireNo++);
                }

                katBilgileri.Add(new KatDaireBilgisi
                {
                    BlokId = kat.BlokId,
                    KatAdi = kat.KatAdi,
                    DaireSayisi = kat.DaireSayisi,
                    DaireNumaralari = daireler
                });
            }

            return katBilgileri;
        }
    }
}