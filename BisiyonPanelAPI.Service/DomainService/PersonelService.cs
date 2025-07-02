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
    public class PersonelService : ServiceBase<Personel>, IPersonelService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PersonelService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<Personel>>> GetAll()
        {
            var items = await _unitOfWork.Repository<Personel>().GetAllAsync();
            if (items == null || items.Data == null || !items.Data.Any())
            {
                return new Result<List<Personel>>
                {
                    State = ResultState.Fail,
                    Message = "Personel Bulunmadı."
                };
            }
            return new Result<List<Personel>>
            {
                State = ResultState.Successfull,
                Data = items.Data.ToList()
            };
        }

        public async Task<Result<Personel>> GetById(int id)
        {
            var item = await _unitOfWork.Repository<Personel>().GetByIdAsync(id);
            if (item == null)
            {
                return new Result<Personel>
                {
                    State = ResultState.Fail,
                    Message = "Personel bulunamadı."
                };
            }
            return new Result<Personel>
            {
                State = ResultState.Successfull,
                Data = item.Data
            };
        }

        public async Task<Result<Personel>> InsertAsync(PersonelBo entity)
        {
            try
            {
                var inserted = await _unitOfWork.Repository<Personel>().Insert<PersonelBo>(entity);
                var addToEntity = await _unitOfWork.SaveChangesAsync();
                return new Result<Personel>
                {
                    State = ResultState.Successfull,
                    Data = _unitOfWork.Repository<Personel>().GetByIdAsync(inserted.Id).Result.Data,
                };
            }
            catch (Exception ex)
            {
                return new Result<Personel>
                {
                    State = ResultState.Fail,
                    Message = "Personel eklenemedi. Hata: " + ex.Message
                };
            }
        }

        public async Task<Result<Personel>> UpdateAsync(PersonelBo entity)
        {
            try
            {
                var existing = await _unitOfWork.Repository<Personel>().GetByIdAsync<PersonelBo>(entity.Id);
                if (existing == null)
                {
                    return new Result<Personel>
                    {
                        State = ResultState.Fail,
                        Message = "Personel bulunamadı."
                    };
                }
                var updated = await _unitOfWork.Repository<Personel>().Update<PersonelBo>(entity);
                var updatedEntity = await _unitOfWork.SaveChangesAsync();
                return new Result<Personel>
                {
                    State = ResultState.Successfull,
                    Data = _unitOfWork.Repository<Personel>().GetByIdAsync(entity.Id).Result.Data,
                };
            }
            catch (Exception ex)
            {
                return new Result<Personel>
                {
                    State = ResultState.Fail,
                    Message = "Personel güncellenemedi. Hata: " + ex.Message
                };
            }
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            try
            {
                await _unitOfWork.Repository<Personel>().Delete(id);
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
                    Message = "Personel silinemedi. Hata: " + ex.Message,
                    Data = false
                };
            }
        }
    }
}