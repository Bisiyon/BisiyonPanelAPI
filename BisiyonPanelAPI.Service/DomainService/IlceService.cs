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
    public class IlceService : ServiceBase<Ilce>, IIlceService
    {
        private readonly IUnitOfWork _unitOfWork;
        public IlceService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<Ilce>>> GetAll()
        {
            var items = await _unitOfWork.Repository<Ilce>().GetAllAsync();
            if (items == null || items.Data == null || !items.Data.Any())
            {
                return new Result<List<Ilce>>
                {
                    State = ResultState.Fail,
                    Message = "Ilce Bulunmadı."
                };
            }
            return new Result<List<Ilce>>
            {
                State = ResultState.Successfull,
                Data = items.Data.ToList()
            };
        }

        public async Task<Result<Ilce>> GetById(int id)
        {
            var item = await _unitOfWork.Repository<Ilce>().GetByIdAsync(id);
            if (item == null)
            {
                return new Result<Ilce>
                {
                    State = ResultState.Fail,
                    Message = "Ilce bulunamadı."
                };
            }
            return new Result<Ilce>
            {
                State = ResultState.Successfull,
                Data = item.Data
            };
        }

        public async Task<Result<Ilce>> InsertAsync(IlceBo entity)
        {
            try
            {
                var inserted = await _unitOfWork.Repository<Ilce>().Insert<IlceBo>(entity);
                var addToEntity = await _unitOfWork.SaveChangesAsync();
                return new Result<Ilce>
                {
                    State = ResultState.Successfull,
                    Data = _unitOfWork.Repository<Ilce>().GetByIdAsync(inserted.Id).Result.Data,
                };
            }
            catch (Exception ex)
            {
                return new Result<Ilce>
                {
                    State = ResultState.Fail,
                    Message = "Ilce eklenemedi. Hata: " + ex.Message
                };
            }
        }

        public async Task<Result<Ilce>> UpdateAsync(IlceBo entity)
        {
            try
            {
                var existing = await _unitOfWork.Repository<Ilce>().GetByIdAsync<IlceBo>(entity.Id);
                if (existing == null)
                {
                    return new Result<Ilce>
                    {
                        State = ResultState.Fail,
                        Message = "Ilce bulunamadı."
                    };
                }
                var updated = await _unitOfWork.Repository<Ilce>().Update<IlceBo>(entity);
                var updatedEntity = await _unitOfWork.SaveChangesAsync();
                return new Result<Ilce>
                {
                    State = ResultState.Successfull,
                    Data = _unitOfWork.Repository<Ilce>().GetByIdAsync(entity.Id).Result.Data,
                };
            }
            catch (Exception ex)
            {
                return new Result<Ilce>
                {
                    State = ResultState.Fail,
                    Message = "Ilce güncellenemedi. Hata: " + ex.Message
                };
            }
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            try
            {
                await _unitOfWork.Repository<Ilce>().Delete(id);
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
                    Message = "Ilce silinemedi. Hata: " + ex.Message,
                    Data = false
                };
            }
        }
    }
}