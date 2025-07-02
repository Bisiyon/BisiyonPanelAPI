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
    public class AracHareketService : ServiceBase<AracHareket>, IAracHareketService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AracHareketService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<Result<List<AracHareket>>> GetAll()
        {
            var aracHarekets = await _unitOfWork.Repository<AracHareket>().GetAllAsync();

            if (aracHarekets == null || aracHarekets.Data == null || !aracHarekets.Data.Any())
            {
                return new Result<List<AracHareket>>
                {
                    State = ResultState.Fail,
                    Message = "AracHareket Bulunmadı."
                };
            }

            return new Result<List<AracHareket>>
            {
                State = ResultState.Successfull,
                Data = aracHarekets.Data.ToList()
            };
        }

        public async Task<Result<AracHareket>> GetById(int id)
        {
            var aracHareket = await _unitOfWork.Repository<AracHareket>().GetByIdAsync(id);

            if (aracHareket == null)
            {
                return new Result<AracHareket>
                {
                    State = ResultState.Fail,
                    Message = "AracHareket bulunamadı."
                };
            }

            return new Result<AracHareket>
            {
                State = ResultState.Successfull,
                Data = aracHareket.Data
            };
        }

        public async Task<Result<AracHareket>> InsertAsync(AracHareketBo entity)
        {
            try
            {
                var inserted = await _unitOfWork.Repository<AracHareket>().Insert<AracHareketBo>(entity);
                var addToAracHareket = await _unitOfWork.SaveChangesAsync();

                return new Result<AracHareket>
                {
                    State = ResultState.Successfull,
                    Data = _unitOfWork.Repository<AracHareket>().GetByIdAsync(inserted.Id).Result.Data,
                };
            }
            catch (Exception ex)
            {
                return new Result<AracHareket>
                {
                    State = ResultState.Fail,
                    Message = "AracHareket eklenemedi. Hata: " + ex.Message
                };
            }
        }

        public async Task<Result<AracHareket>> UpdateAsync(AracHareketBo entity)
        {
            try
            {
                var existing = await _unitOfWork.Repository<AracHareket>().GetByIdAsync<AracHareketBo>(entity.Id);

                if (existing == null)
                {
                    return new Result<AracHareket>
                    {
                        State = ResultState.Fail,
                        Message = "AracHareket bulunamadı."
                    };
                }

                var updated = await _unitOfWork.Repository<AracHareket>().Update<AracHareketBo>(entity);
                var updatedAracHareket = await _unitOfWork.SaveChangesAsync();

                return new Result<AracHareket>
                {
                    State = ResultState.Successfull,
                    Data = _unitOfWork.Repository<AracHareket>().GetByIdAsync(entity.Id).Result.Data,
                };
            }
            catch (Exception ex)
            {
                return new Result<AracHareket>
                {
                    State = ResultState.Fail,
                    Message = "AracHareket güncellenemedi. Hata: " + ex.Message
                };
            }
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            try
            {
                await _unitOfWork.Repository<AracHareket>().Delete(id);
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
                    Message = "AracHareket silinemedi. Hata: " + ex.Message,
                    Data = false
                };
            }
        }
        
        public async Task<Result<AracHareket>> LogAracGirisCikisAsync(int aracId, int aracHareketTipId)
        {
            try
            {
                var arac = await _unitOfWork.Repository<Arac>().GetByIdAsync(aracId);
                if (arac == null)
                {
                    return new Result<AracHareket>
                    {
                        State = ResultState.Fail,
                        Message = "Araç bulunamadı."
                    };
                }

                var aracHareket = new AracHareket
                {
                    AracId = aracId,
                    AracHereketTipId = aracHareketTipId,
                    Tarih = DateTime.Now
                };

                var aracHareketEntity = await _unitOfWork.Repository<AracHareket>().Insert<AracHareket>(aracHareket);

                return new Result<AracHareket>
                {
                    Data = aracHareketEntity,
                    State = ResultState.Successfull
                };
            }
            catch (Exception ex)
            {
                return new Result<AracHareket>
                {
                    State = ResultState.Fail,
                    Message = "Bir hata oluştu: " + ex.Message
                };
            }
        }
    }
}