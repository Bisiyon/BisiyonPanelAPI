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
    public class PersonelGorevService : ServiceBase<PersonelGorev>, IPersonelGorevService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PersonelGorevService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<PersonelGorev>>> GetAll()
        {
            var items = await _unitOfWork.Repository<PersonelGorev>().GetAllAsync();
            if (items == null || items.Data == null || !items.Data.Any())
            {
                return new Result<List<PersonelGorev>>
                {
                    State = ResultState.Fail,
                    Message = "PersonelGorev Bulunmadı."
                };
            }
            return new Result<List<PersonelGorev>>
            {
                State = ResultState.Successfull,
                Data = items.Data.ToList()
            };
        }

        public async Task<Result<PersonelGorev>> GetById(int id)
        {
            var item = await _unitOfWork.Repository<PersonelGorev>().GetByIdAsync(id);
            if (item == null)
            {
                return new Result<PersonelGorev>
                {
                    State = ResultState.Fail,
                    Message = "PersonelGorev bulunamadı."
                };
            }
            return new Result<PersonelGorev>
            {
                State = ResultState.Successfull,
                Data = item.Data
            };
        }

        public async Task<Result<PersonelGorev>> InsertAsync(PersonelGorevBo entity)
        {
            try
            {
                var inserted = await _unitOfWork.Repository<PersonelGorev>().Insert<PersonelGorevBo>(entity);
                var addToEntity = await _unitOfWork.SaveChangesAsync();
                return new Result<PersonelGorev>
                {
                    State = ResultState.Successfull,
                    Data = _unitOfWork.Repository<PersonelGorev>().GetByIdAsync(inserted.Id).Result.Data,
                };
            }
            catch (Exception ex)
            {
                return new Result<PersonelGorev>
                {
                    State = ResultState.Fail,
                    Message = "PersonelGorev eklenemedi. Hata: " + ex.Message
                };
            }
        }

        public async Task<Result<PersonelGorev>> UpdateAsync(PersonelGorevBo entity)
        {
            try
            {
                var existing = await _unitOfWork.Repository<PersonelGorev>().GetByIdAsync<PersonelGorevBo>(entity.Id);
                if (existing == null)
                {
                    return new Result<PersonelGorev>
                    {
                        State = ResultState.Fail,
                        Message = "PersonelGorev bulunamadı."
                    };
                }
                var updated = await _unitOfWork.Repository<PersonelGorev>().Update<PersonelGorevBo>(entity);
                var updatedEntity = await _unitOfWork.SaveChangesAsync();
                return new Result<PersonelGorev>
                {
                    State = ResultState.Successfull,
                    Data = _unitOfWork.Repository<PersonelGorev>().GetByIdAsync(entity.Id).Result.Data,
                };
            }
            catch (Exception ex)
            {
                return new Result<PersonelGorev>
                {
                    State = ResultState.Fail,
                    Message = "PersonelGorev güncellenemedi. Hata: " + ex.Message
                };
            }
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            try
            {
                await _unitOfWork.Repository<PersonelGorev>().Delete(id);
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
                    Message = "PersonelGorev silinemedi. Hata: " + ex.Message,
                    Data = false
                };
            }
        }
    }
}