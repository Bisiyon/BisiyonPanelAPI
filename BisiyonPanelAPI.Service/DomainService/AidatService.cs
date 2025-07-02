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
    public class AidatService : ServiceBase<Aidat>, IAidatService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AidatService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<Result<List<Aidat>>> GetAll()
        {
            var aidats = await _unitOfWork.Repository<Aidat>().GetAllAsync();

            if (aidats == null || aidats.Data == null || !aidats.Data.Any())
            {
                return new Result<List<Aidat>>
                {
                    State = ResultState.Fail,
                    Message = "Aidat Bulunmadı."
                };
            }

            return new Result<List<Aidat>>
            {
                State = ResultState.Successfull,
                Data = aidats.Data.ToList()
            };
        }

        public async Task<Result<Aidat>> GetById(int id)
        {
            var aidat = await _unitOfWork.Repository<Aidat>().GetByIdAsync(id);

            if (aidat == null)
            {
                return new Result<Aidat>
                {
                    State = ResultState.Fail,
                    Message = "Aidat bulunamadı."
                };
            }

            return new Result<Aidat>
            {
                State = ResultState.Successfull,
                Data = aidat.Data
            };
        }

        public async Task<Result<Aidat>> InsertAsync(AidatBo entity)
        {
            try
            {
                var inserted = await _unitOfWork.Repository<Aidat>().Insert<AidatBo>(entity);
                var addToAidat = await _unitOfWork.SaveChangesAsync();

                return new Result<Aidat>
                {
                    State = ResultState.Successfull,
                    Data = _unitOfWork.Repository<Aidat>().GetByIdAsync(inserted.Id).Result.Data,
                };
            }
            catch (Exception ex)
            {
                return new Result<Aidat>
                {
                    State = ResultState.Fail,
                    Message = "Aidat eklenemedi. Hata: " + ex.Message
                };
            }
        }

        public async Task<Result<Aidat>> UpdateAsync(AidatBo entity)
        {
            try
            {
                var existing = await _unitOfWork.Repository<Aidat>().GetByIdAsync<AidatBo>(entity.Id); 

                if (existing == null)
                {
                    return new Result<Aidat>
                    {
                        State = ResultState.Fail,
                        Message = "Aidat bulunamadı."
                    };
                }

                var updated = await _unitOfWork.Repository<Aidat>().Update<AidatBo>(entity);
                var updatedAidat = await _unitOfWork.SaveChangesAsync();

                return new Result<Aidat>
                {
                    State = ResultState.Successfull,
                    Data = _unitOfWork.Repository<Aidat>().GetByIdAsync(entity.Id).Result.Data,
                };
            }
            catch (Exception ex)
            {
                return new Result<Aidat>
                {
                    State = ResultState.Fail,
                    Message = "Aidat güncellenemedi. Hata: " + ex.Message
                };
            }
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            try
            {
                await _unitOfWork.Repository<Aidat>().Delete(id);
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
                    Message = "Aidat silinemedi. Hata: " + ex.Message,
                    Data = false
                };
            }
        }
    }
}