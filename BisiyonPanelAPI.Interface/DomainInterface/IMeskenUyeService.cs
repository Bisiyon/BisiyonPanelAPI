using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.View;
using BisiyonPanelAPI.View.BussinesObjects;

namespace BisiyonPanelAPI.Interface
{
    public interface IMeskenUyeService : IServiceBase<MeskenUye>
    {
        Task<Result<List<MeskenUye>>> GetAll();
        Task<Result<MeskenUye>> GetById(int id);
        Task<Result<MeskenUye>> InsertAsync(MeskenUyeBo entity);
        Task<Result<MeskenUye>> UpdateAsync(MeskenUyeBo entity);
        Task<Result<bool>> DeleteAsync(int id);
    }
}