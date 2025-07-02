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
    public class AidatGrupService : ServiceBase<AidatGrup>, IAidatGrupService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AidatGrupService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<AidatGrup>>> GetAll()
        {
            var items = await _unitOfWork.Repository<AidatGrup>().GetAllAsync();
            if (items == null || items.Data == null || !items.Data.Any())
            {
                return new Result<List<AidatGrup>>
                {
                    State = ResultState.Fail,
                    Message = "AidatGrup Bulunmad�."
                };
            }
            return new Result<List<AidatGrup>>
            {
                State = ResultState.Successfull,
                Data = items.Data.ToList()
            };
        }

        public async Task<Result<AidatGrup>> GetById(int id)
        {
            var item = await _unitOfWork.Repository<AidatGrup>().GetByIdAsync(id);
            if (item == null)
            {
                return new Result<AidatGrup>
                {
                    State = ResultState.Fail,
                    Message = "AidatGrup bulunamad�."
                };
            }
            return new Result<AidatGrup>
            {
                State = ResultState.Successfull,
                Data = item.Data
            };
        }

        public async Task<Result<AidatGrup>> InsertAsync(AidatGrupBo entity)
        {
            try
            {
                var inserted = await _unitOfWork.Repository<AidatGrup>().Insert<AidatGrupBo>(entity);
                var addToEntity = await _unitOfWork.SaveChangesAsync();
                return new Result<AidatGrup>
                {
                    State = ResultState.Successfull,
                    Data = _unitOfWork.Repository<AidatGrup>().GetByIdAsync(inserted.Id).Result.Data,
                };
            }
            catch (Exception ex)
            {
                return new Result<AidatGrup>
                {
                    State = ResultState.Fail,
                    Message = "AidatGrup eklenemedi. Hata: " + ex.Message
                };
            }
        }

        public async Task<Result<AidatGrup>> UpdateAsync(AidatGrupBo entity)
        {
            try
            {
                var existing = await _unitOfWork.Repository<AidatGrup>().GetByIdAsync<AidatGrupBo>(entity.Id);
                if (existing == null)
                {
                    return new Result<AidatGrup>
                    {
                        State = ResultState.Fail,
                        Message = "AidatGrup bulunamad�."
                    };
                }
                var updated = await _unitOfWork.Repository<AidatGrup>().Update<AidatGrupBo>(entity);
                var updatedEntity = await _unitOfWork.SaveChangesAsync();
                return new Result<AidatGrup>
                {
                    State = ResultState.Successfull,
                    Data = _unitOfWork.Repository<AidatGrup>().GetByIdAsync(entity.Id).Result.Data,
                };
            }
            catch (Exception ex)
            {
                return new Result<AidatGrup>
                {
                    State = ResultState.Fail,
                    Message = "AidatGrup g�ncellenemedi. Hata: " + ex.Message
                };
            }
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            try
            {
                await _unitOfWork.Repository<AidatGrup>().Delete(id);
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
                    Message = "AidatGrup silinemedi. Hata: " + ex.Message,
                    Data = false
                };
            }
        }
    }
}