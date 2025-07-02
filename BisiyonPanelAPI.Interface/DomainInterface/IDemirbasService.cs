using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.View;
using BisiyonPanelAPI.View.BussinesObjects;

namespace BisiyonPanelAPI.Interface
{
    public interface IDemirbasService : IServiceBase<Demirbas>
    {
        Task<Result<List<Demirbas>>> GetAll();
        Task<Result<Demirbas>> GetById(int id);
        Task<Result<Demirbas>> InsertAsync(DemirbasBo entity);
        Task<Result<Demirbas>> UpdateAsync(DemirbasBo entity);
        Task<Result<bool>> DeleteAsync(int id);
    }
}
