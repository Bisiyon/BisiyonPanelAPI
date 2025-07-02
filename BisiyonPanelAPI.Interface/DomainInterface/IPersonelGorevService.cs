using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.View;
using BisiyonPanelAPI.View.BussinesObjects;

namespace BisiyonPanelAPI.Interface
{
    public interface IPersonelGorevService : IServiceBase<PersonelGorev>
    {
        Task<Result<List<PersonelGorev>>> GetAll();
        Task<Result<PersonelGorev>> GetById(int id);
        Task<Result<PersonelGorev>> InsertAsync(PersonelGorevBo entity);
        Task<Result<PersonelGorev>> UpdateAsync(PersonelGorevBo entity);
        Task<Result<bool>> DeleteAsync(int id);
    }
}