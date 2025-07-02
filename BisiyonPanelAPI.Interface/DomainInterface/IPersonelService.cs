using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.View;
using BisiyonPanelAPI.View.BussinesObjects;

namespace BisiyonPanelAPI.Interface
{
    public interface IPersonelService : IServiceBase<Personel>
    {
        Task<Result<List<Personel>>> GetAll();
        Task<Result<Personel>> GetById(int id);
        Task<Result<Personel>> InsertAsync(PersonelBo entity);
        Task<Result<Personel>> UpdateAsync(PersonelBo entity);
        Task<Result<bool>> DeleteAsync(int id);
    }
}