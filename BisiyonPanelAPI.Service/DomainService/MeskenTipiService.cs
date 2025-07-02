using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Infrastructure;
using BisiyonPanelAPI.Interface;
using BisiyonPanelAPI.View;
using BisiyonPanelAPI.View.BussinesObjects;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BisiyonPanelAPI.Service
{
    public class MeskenTipiService : ServiceBase<MeskenTipi>, IMeskenTipiService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MeskenTipiService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<MeskenTipi>>> GetAll()
        {
            var items = await _unitOfWork.Repository<MeskenTipi>().GetAllAsync();
            if (items == null || items.Data == null || !items.Data.Any())
            {
                return new Result<List<MeskenTipi>>
                {
                    State = ResultState.Fail,
                    Message = "MeskenTipi Bulunmadı."
                };
            }
            return new Result<List<MeskenTipi>>
            {
                State = ResultState.Successfull,
                Data = items.Data.ToList()
            };
        }

        public async Task<Result<MeskenTipi>> GetById(int id)
        {
            var item = await _unitOfWork.Repository<MeskenTipi>().GetByIdAsync(id);
            if (item == null)
            {
                return new Result<MeskenTipi>
                {
                    State = ResultState.Fail,
                    Message = "MeskenTipi bulunamadı."
                };
            }
            return new Result<MeskenTipi>
            {
                State = ResultState.Successfull,
                Data = item.Data
            };
        }

        public async Task<Result<MeskenTipi>> InsertAsync(MeskenTipiBo entity)
        {
            try
            {
                var inserted = await _unitOfWork.Repository<MeskenTipi>().Insert<MeskenTipiBo>(entity);
                var addToEntity = await _unitOfWork.SaveChangesAsync();
                return new Result<MeskenTipi>
                {
                    State = ResultState.Successfull,
                    Data = _unitOfWork.Repository<MeskenTipi>().GetByIdAsync(inserted.Id).Result.Data,
                };
            }
            catch (Exception ex)
            {
                return new Result<MeskenTipi>
                {
                    State = ResultState.Fail,
                    Message = "MeskenTipi eklenemedi. Hata: " + ex.Message
                };
            }
        }

        public async Task<Result<MeskenTipi>> UpdateAsync(MeskenTipiBo entity)
        {
            try
            {
                var existing = await _unitOfWork.Repository<MeskenTipi>().GetByIdAsync<MeskenTipiBo>(entity.Id);
                if (existing == null)
                {
                    return new Result<MeskenTipi>
                    {
                        State = ResultState.Fail,
                        Message = "MeskenTipi bulunamadı."
                    };
                }
                var updated = await _unitOfWork.Repository<MeskenTipi>().Update<MeskenTipiBo>(entity);
                var updatedEntity = await _unitOfWork.SaveChangesAsync();
                return new Result<MeskenTipi>
                {
                    State = ResultState.Successfull,
                    Data = _unitOfWork.Repository<MeskenTipi>().GetByIdAsync(entity.Id).Result.Data,
                };
            }
            catch (Exception ex)
            {
                return new Result<MeskenTipi>
                {
                    State = ResultState.Fail,
                    Message = "MeskenTipi güncellenemedi. Hata: " + ex.Message
                };
            }
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            try
            {
                await _unitOfWork.Repository<MeskenTipi>().Delete(id);
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
                    Message = "MeskenTipi silinemedi. Hata: " + ex.Message,
                    Data = false
                };
            }
        }
    }
}