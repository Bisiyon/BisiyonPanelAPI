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
    public class UyeService : ServiceBase<Uye>, IUyeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UyeService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<Uye>>> GetAll()
        {
            var items = await _unitOfWork.Repository<Uye>().GetAllAsync();
            if (items == null || items.Data == null || !items.Data.Any())
            {
                return new Result<List<Uye>>
                {
                    State = ResultState.Fail,
                    Message = "Uye Bulunmadı."
                };
            }
            return new Result<List<Uye>>
            {
                State = ResultState.Successfull,
                Data = items.Data.ToList()
            };
        }

        public async Task<Result<Uye>> GetById(int id)
        {
            var item = await _unitOfWork.Repository<Uye>().GetByIdAsync(id);
            if (item == null)
            {
                return new Result<Uye>
                {
                    State = ResultState.Fail,
                    Message = "Uye bulunamadı."
                };
            }
            return new Result<Uye>
            {
                State = ResultState.Successfull,
                Data = item.Data
            };
        }

        public async Task<Result<Uye>> InsertAsync(UyeBo entity)
        {
            try
            {
                var inserted = await _unitOfWork.Repository<Uye>().Insert<UyeBo>(entity);
                var addToEntity = await _unitOfWork.SaveChangesAsync();
                return new Result<Uye>
                {
                    State = ResultState.Successfull,
                    Data = _unitOfWork.Repository<Uye>().GetByIdAsync(inserted.Id).Result.Data,
                };
            }
            catch (Exception ex)
            {
                return new Result<Uye>
                {
                    State = ResultState.Fail,
                    Message = "Uye eklenemedi. Hata: " + ex.Message
                };
            }
        }

        public async Task<Result<Uye>> UpdateAsync(UyeBo entity)
        {
            try
            {
                var existing = await _unitOfWork.Repository<Uye>().GetByIdAsync<UyeBo>(entity.Id);
                if (existing == null)
                {
                    return new Result<Uye>
                    {
                        State = ResultState.Fail,
                        Message = "Uye bulunamadı."
                    };
                }
                var updated = await _unitOfWork.Repository<Uye>().Update<UyeBo>(entity);
                var updatedEntity = await _unitOfWork.SaveChangesAsync();
                return new Result<Uye>
                {
                    State = ResultState.Successfull,
                    Data = _unitOfWork.Repository<Uye>().GetByIdAsync(entity.Id).Result.Data,
                };
            }
            catch (Exception ex)
            {
                return new Result<Uye>
                {
                    State = ResultState.Fail,
                    Message = "Uye güncellenemedi. Hata: " + ex.Message
                };
            }
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            try
            {
                await _unitOfWork.Repository<Uye>().Delete(id);
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
                    Message = "Uye silinemedi. Hata: " + ex.Message,
                    Data = false
                };
            }
        }

        public async Task<Result<UyeBo>> CreateUye(UyeBo bo)
        {
            var result = new Result<UyeBo>() { State = ResultState.Fail };
            try
            {
                var uye = await _unitOfWork.Repository<Uye>().Insert<UyeBo>(bo);

                var addToUye = await _unitOfWork.SaveChangesAsync();
                if (addToUye.IsSuccessfull)
                {
                    result = await _unitOfWork.Repository<Uye>().GetByIdAsync<UyeBo>(uye.Id);
                }
            }
            catch (System.Exception ex)
            {

            }

            return result;
        }
    }
}