using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.View;
using BisiyonPanelAPI.View.BussinesObjects;

namespace BisiyonPanelAPI.Interface
{
    public interface IIlService : IServiceBase<Il>
    {
        Task<Result<List<Il>>> GetAll();
        Task<Result<Il>> GetById(int id);
        Task<Result<Il>> InsertAsync(IlBo entity);
        Task<Result<Il>> UpdateAsync(IlBo entity);
        Task<Result<bool>> DeleteAsync(int id);
    }
}