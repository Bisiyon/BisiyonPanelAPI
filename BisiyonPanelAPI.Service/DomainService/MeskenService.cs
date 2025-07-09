using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Infrastructure;
using BisiyonPanelAPI.Interface;
using BisiyonPanelAPI.View;
using BisiyonPanelAPI.View.BussinesObjects;
using BisiyonPanelAPI.View.MeskenView.Response;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BisiyonPanelAPI.Service
{
    public class MeskenService : ServiceBase<Mesken>, IMeskenService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MeskenService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<Mesken>>> GetAll()
        {
            var items = await _unitOfWork.Repository<Mesken>().GetAllAsync();
            if (items == null || items.Data == null || !items.Data.Any())
            {
                return new Result<List<Mesken>>
                {
                    State = ResultState.Fail,
                    Message = "Mesken Bulunmadı."
                };
            }
            return new Result<List<Mesken>>
            {
                State = ResultState.Successfull,
                Data = items.Data.ToList()
            };
        }

        public async Task<Result<Mesken>> GetById(int id)
        {
            var item = await _unitOfWork.Repository<Mesken>().GetByIdAsync(id);
            if (item == null)
            {
                return new Result<Mesken>
                {
                    State = ResultState.Fail,
                    Message = "Mesken bulunamadı."
                };
            }
            return new Result<Mesken>
            {
                State = ResultState.Successfull,
                Data = item.Data
            };
        }

        public async Task<Result<Mesken>> InsertAsync(MeskenBo entity)
        {
            try
            {
                var inserted = await _unitOfWork.Repository<Mesken>().Insert<MeskenBo>(entity);
                var addToEntity = await _unitOfWork.SaveChangesAsync();
                return new Result<Mesken>
                {
                    State = ResultState.Successfull,
                    Data = _unitOfWork.Repository<Mesken>().GetByIdAsync(inserted.Id).Result.Data,
                };
            }
            catch (Exception ex)
            {
                return new Result<Mesken>
                {
                    State = ResultState.Fail,
                    Message = "Mesken eklenemedi. Hata: " + ex.Message
                };
            }
        }

        public async Task<Result<Mesken>> UpdateAsync(MeskenBo entity)
        {
            try
            {
                var existing = await _unitOfWork.Repository<Mesken>().GetByIdAsync<MeskenBo>(entity.Id);
                if (existing == null)
                {
                    return new Result<Mesken>
                    {
                        State = ResultState.Fail,
                        Message = "Mesken bulunamadı."
                    };
                }
                var updated = await _unitOfWork.Repository<Mesken>().Update<MeskenBo>(entity);
                var updatedEntity = await _unitOfWork.SaveChangesAsync();
                return new Result<Mesken>
                {
                    State = ResultState.Successfull,
                    Data = _unitOfWork.Repository<Mesken>().GetByIdAsync(entity.Id).Result.Data,
                };
            }
            catch (Exception ex)
            {
                return new Result<Mesken>
                {
                    State = ResultState.Fail,
                    Message = "Mesken güncellenemedi. Hata: " + ex.Message
                };
            }
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            try
            {
                await _unitOfWork.Repository<Mesken>().Delete(id);
                await _unitOfWork.SaveChangesAsync();
                return new Result<bool>
                {
                    State = ResultState.Successfull,
                    Data = true
                };
            }
            catch (Exception ex)
            {
                return new Result<bool>
                {
                    State = ResultState.Fail,
                    Message = "Mesken silinemedi. Hata: " + ex.Message,
                    Data = false
                };
            }
        }

        public async Task<PagedResult<List<GetAllMeskenListResponseDto>>> GetAllMeskenList(DataFilterModelView model)
        {
            var result = await _unitOfWork.Repository<Mesken>().GetAllAsync<GetAllMeskenListResponseDto>(model, query =>
            query.Include(x => x.Blok)
                .Include(x => x.MeskenTipi)
                .Include(x => x.AidatGrup)
                .Include(x => x.MeskenUyes).ThenInclude(x => x.Uye));
            return result;
        }
    }
}