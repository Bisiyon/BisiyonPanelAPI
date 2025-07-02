using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.View;
using BisiyonPanelAPI.View.BussinesObjects;

namespace BisiyonPanelAPI.Interface
{
    public interface IPersonelGorevHareketService : IServiceBase<PersonelGorevHareket>
    {
        Task<Result<List<PersonelGorevHareket>>> GetAll();
        Task<Result<PersonelGorevHareket>> GetById(int id);
        Task<Result<PersonelGorevHareket>> InsertAsync(PersonelGorevHareketBo entity);
        Task<Result<PersonelGorevHareket>> UpdateAsync(PersonelGorevHareketBo entity);
        Task<Result<bool>> DeleteAsync(int id);
    }
}