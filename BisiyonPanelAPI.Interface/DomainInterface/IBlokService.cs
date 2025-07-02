using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.View;
using BisiyonPanelAPI.View.BussinesObjects;

namespace BisiyonPanelAPI.Interface
{
    public interface IBlokService : IServiceBase<Blok>
    {
        Task<Result<List<Blok>>> GetAll();
        Task<Result<Blok>> GetById(int id);
        Task<Result<Blok>> InsertAsync(BlokBo entity);
        Task<Result<Blok>> UpdateAsync(BlokBo entity);
        Task<Result<bool>> DeleteAsync(int id);
        Task<Result<BlokBo>> CreateBlokWithMesken(CreateNewBlokWithMeskenRequestDto dto);
    }
}