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
    public class UyeHareketService : ServiceBase<UyeHareket>, IUyeHareketService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UyeHareketService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<UyeHareket>>> GetAll()
        {
            var items = await _unitOfWork.Repository<UyeHareket>().GetAllAsync();
            if (items == null || items.Data == null || !items.Data.Any())
            {
                return new Result<List<UyeHareket>>
                {
                    State = ResultState.Fail,
                    Message = "UyeHareket Bulunmadı."
                };
            }
            return new Result<List<UyeHareket>>
            {
                State = ResultState.Successfull,
                Data = items.Data.ToList()
            };
        }

        public async Task<Result<UyeHareket>> GetById(int id)
        {
            var item = await _unitOfWork.Repository<UyeHareket>().GetByIdAsync(id);
            if (item == null)
            {
                return new Result<UyeHareket>
                {
                    State = ResultState.Fail,
                    Message = "UyeHareket bulunamadı."
                };
            }
            return new Result<UyeHareket>
            {
                State = ResultState.Successfull,
                Data = item.Data
            };
        }

        public async Task<Result<UyeHareket>> InsertAsync(UyeHareketBo entity)
        {
            try
            {
                var inserted = await _unitOfWork.Repository<UyeHareket>().Insert<UyeHareketBo>(entity);
                var addToEntity = await _unitOfWork.SaveChangesAsync();
                return new Result<UyeHareket>
                {
                    State = ResultState.Successfull,
                    Data = _unitOfWork.Repository<UyeHareket>().GetByIdAsync(inserted.Id).Result.Data,
                };
            }
            catch (Exception ex)
            {
                return new Result<UyeHareket>
                {
                    State = ResultState.Fail,
                    Message = "UyeHareket eklenemedi. Hata: " + ex.Message
                };
            }
        }

        public async Task<Result<UyeHareket>> UpdateAsync(UyeHareketBo entity)
        {
            try
            {
                var existing = await _unitOfWork.Repository<UyeHareket>().GetByIdAsync<UyeHareketBo>(entity.Id);
                if (existing == null)
                {
                    return new Result<UyeHareket>
                    {
                        State = ResultState.Fail,
                        Message = "UyeHareket bulunamadı."
                    };
                }
                var updated = await _unitOfWork.Repository<UyeHareket>().Update<UyeHareketBo>(entity);
                var updatedEntity = await _unitOfWork.SaveChangesAsync();
                return new Result<UyeHareket>
                {
                    State = ResultState.Successfull,
                    Data = _unitOfWork.Repository<UyeHareket>().GetByIdAsync(entity.Id).Result.Data,
                };
            }
            catch (Exception ex)
            {
                return new Result<UyeHareket>
                {
                    State = ResultState.Fail,
                    Message = "UyeHareket güncellenemedi. Hata: " + ex.Message
                };
            }
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            try
            {
                await _unitOfWork.Repository<UyeHareket>().Delete(id);
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
                    Message = "UyeHareket silinemedi. Hata: " + ex.Message,
                    Data = false
                };
            }
        }
    }
}