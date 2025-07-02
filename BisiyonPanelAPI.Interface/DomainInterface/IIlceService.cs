using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.View;
using BisiyonPanelAPI.View.BussinesObjects;

namespace BisiyonPanelAPI.Interface
{
    public interface IIlceService : IServiceBase<Ilce>
    {
        Task<Result<List<Ilce>>> GetAll();
        Task<Result<Ilce>> GetById(int id);
        Task<Result<Ilce>> InsertAsync(IlceBo entity);
        Task<Result<Ilce>> UpdateAsync(IlceBo entity);
        Task<Result<bool>> DeleteAsync(int id);
    }
}