using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.View;
using BisiyonPanelAPI.View.BussinesObjects;
using BisiyonPanelAPI.View.MeskenView.Response;

namespace BisiyonPanelAPI.Interface
{
    public interface IMeskenService : IServiceBase<Mesken>
    {
        Task<Result<List<Mesken>>> GetAll();
        Task<Result<MeskenBo>> GetById(int id);
        Task<Result<Mesken>> InsertAsync(MeskenBo entity);
        Task<Result<Mesken>> UpdateAsync(MeskenBo entity);
        Task<Result<bool>> DeleteAsync(int id);
        Task<PagedResult<List<GetAllMeskenListResponseDto>>> GetAllMeskenList(DataFilterModelView model);
    }
}