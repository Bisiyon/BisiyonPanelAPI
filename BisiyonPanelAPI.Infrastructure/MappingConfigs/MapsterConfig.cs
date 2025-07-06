

using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.View.MeskenView.Response;
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
                .Map(dest => dest.MalSahibi, src => src.MeskenUyes.FirstOrDefault(x => x.Uye.UyeDurumTip.EnumId == Enum_UyeDurumTip.EvSahibi).Uye.Ad)
                .Map(dest => dest.Oturan, src => src.MeskenUyes.FirstOrDefault(x => x.Uye.UyeDurumTip.EnumId == Enum_UyeDurumTip.Kiraci).Uye.Ad);

                // .Map(dest => dest.Oturan, src => src.MeskenUyes.FirstOrDefault(x => x.Uye.UyeDurumTipId == ).Uye.Ad);

            #endregion
        }
}
}