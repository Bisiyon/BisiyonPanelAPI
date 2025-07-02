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
    public class AracService : ServiceBase<Arac>, IAracService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AracService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<Arac>>> GetAll()
        {
            var aracs = await _unitOfWork.Repository<Arac>().GetAllAsync();

            if (aracs == null || aracs.Data == null || !aracs.Data.Any())
            {
                return new Result<List<Arac>>
                {
                    State = ResultState.Fail,
                    Message = "Arac Bulunmadı."
                };
            }

            return new Result<List<Arac>>
            {
                State = ResultState.Successfull,
                Data = aracs.Data.ToList()
            };
        }

        public async Task<Result<Arac>> GetById(int id)
        {
            var arac = await _unitOfWork.Repository<Arac>().GetByIdAsync(id);

            if (arac == null)
            {
                return new Result<Arac>
                {
                    State = ResultState.Fail,
                    Message = "Arac bulunamadı."
                };
            }

            return new Result<Arac>
            {
                State = ResultState.Successfull,
                Data = arac.Data
            };
        }

        public async Task<Result<Arac>> InsertAsync(AracBo entity)
        {
            try
            {
                var inserted = await _unitOfWork.Repository<Arac>().Insert<AracBo>(entity);
                var addToArac = await _unitOfWork.SaveChangesAsync();

                return new Result<Arac>
                {
                    State = ResultState.Successfull,
                    Data = _unitOfWork.Repository<Arac>().GetByIdAsync(inserted.Id).Result.Data,
                };
            }
            catch (Exception ex)
            {
                return new Result<Arac>
                {
                    State = ResultState.Fail,
                    Message = "Arac eklenemedi. Hata: " + ex.Message
                };
            }
        }

        public async Task<Result<Arac>> UpdateAsync(AracBo entity)
        {
            try
            {
                var existing = await _unitOfWork.Repository<Arac>().GetByIdAsync<AracBo>(entity.Id);

                if (existing == null)
                {
                    return new Result<Arac>
                    {
                        State = ResultState.Fail,
                        Message = "Arac bulunamadı."
                    };
                }

                var updated = await _unitOfWork.Repository<Arac>().Update<AracBo>(entity);
                var updatedArac = await _unitOfWork.SaveChangesAsync();

                return new Result<Arac>
                {
                    State = ResultState.Successfull,
                    Data = _unitOfWork.Repository<Arac>().GetByIdAsync(entity.Id).Result.Data,
                };
            }
            catch (Exception ex)
            {
                return new Result<Arac>
                {
                    State = ResultState.Fail,
                    Message = "Arac güncellenemedi. Hata: " + ex.Message
                };
            }
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            try
            {
                await _unitOfWork.Repository<Arac>().Delete(id);
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
                    Message = "Arac silinemedi. Hata: " + ex.Message,
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