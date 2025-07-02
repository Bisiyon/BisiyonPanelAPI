using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.View;
using BisiyonPanelAPI.View.BussinesObjects;

namespace BisiyonPanelAPI.Interface
{
    public interface IBlokService : IServiceBase<Blok>
    {
        Task<Result<BlokBo>> CreateBlokWithMesken(CreateNewBlokWithMeskenRequestDto dto);
    }
}