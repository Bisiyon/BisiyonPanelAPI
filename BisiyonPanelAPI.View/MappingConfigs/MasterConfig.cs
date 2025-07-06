using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.View.MeskenView.Response;
using Mapster;

namespace BisiyonPanelAPI.View
{
public static class MapsterConfig
{
        public static void RegisterMappings()
        {
            #region  Mesken Tipi için Mapper Configs
            TypeAdapterConfig<Mesken, GetAllMeskenListResponseDto>
                .NewConfig()
                .Map(dest => dest.BlokName, src => src.Blok.Ad);
            #endregion
    }
}
}