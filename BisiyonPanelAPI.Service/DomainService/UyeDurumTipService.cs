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
    public class UyeDurumTipService : ServiceBase<UyeDurumTip>, IUyeDurumTipService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UyeDurumTipService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<UyeDurumTip>>> GetAll()
        {
            var items = await _unitOfWork.Repository<UyeDurumTip>().GetAllAsync();
            if (items == null || items.Data == null || !items.Data.Any())
            {
                return new Result<List<UyeDurumTip>>
                {
                    State = ResultState.Fail,
                    Message = "UyeDurumTip Bulunmadı."
                };
            }
            return new Result<List<UyeDurumTip>>
            {
                State = ResultState.Successfull,
                Data = items.Data.ToList()
            };
        }

        public async Task<Result<UyeDurumTip>> GetById(int id)
        {
            var item = await _unitOfWork.Repository<UyeDurumTip>().GetByIdAsync(id);
            if (item == null)
            {
                return new Result<UyeDurumTip>
                {
                    State = ResultState.Fail,
                    Message = "UyeDurumTip bulunamadı."
                };
            }
            return new Result<UyeDurumTip>
            {
                State = ResultState.Successfull,
                Data = item.Data
            };
        }

        public async Task<Result<UyeDurumTip>> InsertAsync(UyeDurumTipBo entity)
        {
            try
            {
                var inserted = await _unitOfWork.Repository<UyeDurumTip>().Insert<UyeDurumTipBo>(entity);
                var addToEntity = await _unitOfWork.SaveChangesAsync();
                return new Result<UyeDurumTip>
                {
                    State = ResultState.Successfull,
                    Data = _unitOfWork.Repository<UyeDurumTip>().GetByIdAsync(inserted.Id).Result.Data,
                };
            }
            catch (Exception ex)
            {
                return new Result<UyeDurumTip>
                {
                    State = ResultState.Fail,
                    Message = "UyeDurumTip eklenemedi. Hata: " + ex.Message
                };
            }
        }

        public async Task<Result<UyeDurumTip>> UpdateAsync(UyeDurumTipBo entity)
        {
            try
            {
                var existing = await _unitOfWork.Repository<UyeDurumTip>().GetByIdAsync<UyeDurumTipBo>(entity.Id);
                if (existing == null)
                {
                    return new Result<UyeDurumTip>
                    {
                        State = ResultState.Fail,
                        Message = "UyeDurumTip bulunamadı."
                    };
                }
                var updated = await _unitOfWork.Repository<UyeDurumTip>().Update<UyeDurumTipBo>(entity);
                var updatedEntity = await _unitOfWork.SaveChangesAsync();
                return new Result<UyeDurumTip>
                {
                    State = ResultState.Successfull,
                    Data = _unitOfWork.Repository<UyeDurumTip>().GetByIdAsync(entity.Id).Result.Data,
                };
            }
            catch (Exception ex)
            {
                return new Result<UyeDurumTip>
                {
                    State = ResultState.Fail,
                    Message = "UyeDurumTip güncellenemedi. Hata: " + ex.Message
                };
            }
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            try
            {
                await _unitOfWork.Repository<UyeDurumTip>().Delete(id);
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
                    Message = "UyeDurumTip silinemedi. Hata: " + ex.Message,
                    Data = false
                };
            }
        }
    }
}
