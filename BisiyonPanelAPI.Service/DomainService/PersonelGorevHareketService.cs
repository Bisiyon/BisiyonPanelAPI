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
    public class PersonelGorevHareketService : ServiceBase<PersonelGorevHareket>, IPersonelGorevHareketService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PersonelGorevHareketService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<PersonelGorevHareket>>> GetAll()
        {
            var items = await _unitOfWork.Repository<PersonelGorevHareket>().GetAllAsync();
            if (items == null || items.Data == null || !items.Data.Any())
            {
                return new Result<List<PersonelGorevHareket>>
                {
                    State = ResultState.Fail,
                    Message = "PersonelGorevHareket Bulunmadı."
                };
            }
            return new Result<List<PersonelGorevHareket>>
            {
                State = ResultState.Successfull,
                Data = items.Data.ToList()
            };
        }

        public async Task<Result<PersonelGorevHareket>> GetById(int id)
        {
            var item = await _unitOfWork.Repository<PersonelGorevHareket>().GetByIdAsync(id);
            if (item == null)
            {
                return new Result<PersonelGorevHareket>
                {
                    State = ResultState.Fail,
                    Message = "PersonelGorevHareket bulunamadı."
                };
            }
            return new Result<PersonelGorevHareket>
            {
                State = ResultState.Successfull,
                Data = item.Data
            };
        }

        public async Task<Result<PersonelGorevHareket>> InsertAsync(PersonelGorevHareketBo entity)
        {
            try
            {
                var inserted = await _unitOfWork.Repository<PersonelGorevHareket>().Insert<PersonelGorevHareketBo>(entity);
                var addToEntity = await _unitOfWork.SaveChangesAsync();
                return new Result<PersonelGorevHareket>
                {
                    State = ResultState.Successfull,
                    Data = _unitOfWork.Repository<PersonelGorevHareket>().GetByIdAsync(inserted.Id).Result.Data,
                };
            }
            catch (Exception ex)
            {
                return new Result<PersonelGorevHareket>
                {
                    State = ResultState.Fail,
                    Message = "PersonelGorevHareket eklenemedi. Hata: " + ex.Message
                };
            }
        }

        public async Task<Result<PersonelGorevHareket>> UpdateAsync(PersonelGorevHareketBo entity)
        {
            try
            {
                var existing = await _unitOfWork.Repository<PersonelGorevHareket>().GetByIdAsync<PersonelGorevHareketBo>(entity.Id);
                if (existing == null)
                {
                    return new Result<PersonelGorevHareket>
                    {
                        State = ResultState.Fail,
                        Message = "PersonelGorevHareket bulunamadı."
                    };
                }
                var updated = await _unitOfWork.Repository<PersonelGorevHareket>().Update<PersonelGorevHareketBo>(entity);
                var updatedEntity = await _unitOfWork.SaveChangesAsync();
                return new Result<PersonelGorevHareket>
                {
                    State = ResultState.Successfull,
                    Data = _unitOfWork.Repository<PersonelGorevHareket>().GetByIdAsync(entity.Id).Result.Data,
                };
            }
            catch (Exception ex)
            {
                return new Result<PersonelGorevHareket>
                {
                    State = ResultState.Fail,
                    Message = "PersonelGorevHareket güncellenemedi. Hata: " + ex.Message
                };
            }
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            try
            {
                await _unitOfWork.Repository<PersonelGorevHareket>().Delete(id);
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
                    Message = "PersonelGorevHareket silinemedi. Hata: " + ex.Message,
                    Data = false
                };
            }
        }
    }
}