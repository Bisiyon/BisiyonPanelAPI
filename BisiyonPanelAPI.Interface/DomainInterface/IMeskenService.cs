using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.View;
using BisiyonPanelAPI.View.BussinesObjects;

namespace BisiyonPanelAPI.Interface
{
    public interface IMeskenService : IServiceBase<Mesken>
    {
        Task<Result<List<Mesken>>> GetAll();
        Task<Result<Mesken>> GetById(int id);
        Task<Result<Mesken>> InsertAsync(MeskenBo entity);
        Task<Result<Mesken>> UpdateAsync(MeskenBo entity);
        Task<Result<bool>> DeleteAsync(int id);
    }
}