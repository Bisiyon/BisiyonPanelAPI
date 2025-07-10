

using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.View.MeskenView.Response;
using BisiyonPanelAPI.View.UyeView.Response;
using Mapster;

namespace BisiyonPanelAPI.Common.MappingConfigs
{
    public static class MapsterConfig
    {
        public static void RegisterMappings()
        {
            #region  Mesken Tipi için Mapper Configs
            TypeAdapterConfig<Mesken, GetAllMeskenListResponseDto>
                .NewConfig()
                .Map(dest => dest.BlokName, src => src.Blok.Ad)
                .Map(dest => dest.MalSahibi, src => src.MeskenUyes.FirstOrDefault(x => x.UyeDurumTip.EnumId == Enum_UyeDurumTip.EvSahibi).Uye.Ad)
                .Map(dest => dest.Oturan, src => src.MeskenUyes.FirstOrDefault(x => x.UyeDurumTip.EnumId == Enum_UyeDurumTip.Kiraci).Uye.Ad)
                .Map(dest => dest.AidatGrubuAdi, src => src.AidatGrup.Ad);

            // .Map(dest => dest.Oturan, src => src.MeskenUyes.FirstOrDefault(x => x.Uye.UyeDurumTipId == ).Uye.Ad);

            #endregion


            TypeAdapterConfig<MeskenUye, MeskenUyeListView>
               .NewConfig()
               .Map(dest => dest.FullName, src => src.Uye.Ad + " " + src.Uye.Soyad)
               .Map(dest => dest.UyeTipIsmi, src => src.UyeDurumTip.Durum)
               .Map(dest => dest.MalikHisse, src => src.MalikHisse.ToString() + "%")
               .Map(dest => dest.Miktar, src => src.MalikHisse.ToString() + "%")
               .Map(dest => dest.BaslangicTarihi, src => src.Uye.UyeHarekets.Where(x => x.HareketTipId == (int)Enum_UyeHareketTip.TasinmaGiris).OrderByDescending(x => x.IslemTarih).FirstOrDefault().IslemTarih.ToString("dd.MM.yyyy"))
               .Map(dest => dest.BitisTarihi, src => src.Uye.UyeHarekets.Where(x => x.HareketTipId == (int)Enum_UyeHareketTip.TasinmaCikis).OrderByDescending(x => x.IslemTarih).FirstOrDefault().IslemTarih.ToString("dd.MM.yyyy"));
        }
    }
}