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
    public class PersonelTipService : ServiceBase<PersonelTip>, IPersonelTipService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PersonelTipService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<PersonelTip>>> GetAll()
        {
            var items = await _unitOfWork.Repository<PersonelTip>().GetAllAsync();
            if (items == null || items.Data == null || !items.Data.Any())
            {
                return new Result<List<PersonelTip>>
                {
                    State = ResultState.Fail,
                    Message = "PersonelTip Bulunmadı."
                };
            }
            return new Result<List<PersonelTip>>
            {
                State = ResultState.Successfull,
                Data = items.Data.ToList()
            };
        }

        public async Task<Result<PersonelTip>> GetById(int id)
        {
            var item = await _unitOfWork.Repository<PersonelTip>().GetByIdAsync(id);
            if (item == null)
            {
                return new Result<PersonelTip>
                {
                    State = ResultState.Fail,
                    Message = "PersonelTip bulunamadı."
                };
            }
            return new Result<PersonelTip>
            {
                State = ResultState.Successfull,
                Data = item.Data
            };
        }

        public async Task<Result<PersonelTip>> InsertAsync(PersonelTipBo entity)
        {
            try
            {
                var inserted = await _unitOfWork.Repository<PersonelTip>().Insert<PersonelTipBo>(entity);
                var addToEntity = await _unitOfWork.SaveChangesAsync();
                return new Result<PersonelTip>
                {
                    State = ResultState.Successfull,
                    Data = _unitOfWork.Repository<PersonelTip>().GetByIdAsync(inserted.Id).Result.Data,
                };
            }
            catch (Exception ex)
            {
                return new Result<PersonelTip>
                {
                    State = ResultState.Fail,
                    Message = "PersonelTip eklenemedi. Hata: " + ex.Message
                };
            }
        }

        public async Task<Result<PersonelTip>> UpdateAsync(PersonelTipBo entity)
        {
            try
            {
                var existing = await _unitOfWork.Repository<PersonelTip>().GetByIdAsync<PersonelTipBo>(entity.Id);
                if (existing == null)
                {
                    return new Result<PersonelTip>
                    {
                        State = ResultState.Fail,
                        Message = "PersonelTip bulunamadı."
                    };
                }
                var updated = await _unitOfWork.Repository<PersonelTip>().Update<PersonelTipBo>(entity);
                var updatedEntity = await _unitOfWork.SaveChangesAsync();
                return new Result<PersonelTip>
                {
                    State = ResultState.Successfull,
                    Data = _unitOfWork.Repository<PersonelTip>().GetByIdAsync(entity.Id).Result.Data,
                };
            }
            catch (Exception ex)
            {
                return new Result<PersonelTip>
                {
                    State = ResultState.Fail,
                    Message = "PersonelTip güncellenemedi. Hata: " + ex.Message
                };
            }
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            try
            {
                await _unitOfWork.Repository<PersonelTip>().Delete(id);
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
                    Message = "PersonelTip silinemedi. Hata: " + ex.Message,
                    Data = false
                };
            }
        }
    }
}