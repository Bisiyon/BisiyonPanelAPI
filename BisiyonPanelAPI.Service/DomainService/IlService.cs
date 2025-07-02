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
    public class IlService : ServiceBase<Il>, IIlService
    {
        private readonly IUnitOfWork _unitOfWork;
        public IlService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<Il>>> GetAll()
        {
            var items = await _unitOfWork.Repository<Il>().GetAllAsync();
            if (items == null || items.Data == null || !items.Data.Any())
            {
                return new Result<List<Il>>
                {
                    State = ResultState.Fail,
                    Message = "Il Bulunmadı."
                };
            }
            return new Result<List<Il>>
            {
                State = ResultState.Successfull,
                Data = items.Data.ToList()
            };
        }

        public async Task<Result<Il>> GetById(int id)
        {
            var item = await _unitOfWork.Repository<Il>().GetByIdAsync(id);
            if (item == null)
            {
                return new Result<Il>
                {
                    State = ResultState.Fail,
                    Message = "Il bulunamadı."
                };
            }
            return new Result<Il>
            {
                State = ResultState.Successfull,
                Data = item.Data
            };
        }

        public async Task<Result<Il>> InsertAsync(IlBo entity)
        {
            try
            {
                var inserted = await _unitOfWork.Repository<Il>().Insert<IlBo>(entity);
                var addToEntity = await _unitOfWork.SaveChangesAsync();
                return new Result<Il>
                {
                    State = ResultState.Successfull,
                    Data = _unitOfWork.Repository<Il>().GetByIdAsync(inserted.Id).Result.Data,
                };
            }
            catch (Exception ex)
            {
                return new Result<Il>
                {
                    State = ResultState.Fail,
                    Message = "Il eklenemedi. Hata: " + ex.Message
                };
            }
        }

        public async Task<Result<Il>> UpdateAsync(IlBo entity)
        {
            try
            {
                var existing = await _unitOfWork.Repository<Il>().GetByIdAsync<IlBo>(entity.Id);
                if (existing == null)
                {
                    return new Result<Il>
                    {
                        State = ResultState.Fail,
                        Message = "Il bulunamadı."
                    };
                }
                var updated = await _unitOfWork.Repository<Il>().Update<IlBo>(entity);
                var updatedEntity = await _unitOfWork.SaveChangesAsync();
                return new Result<Il>
                {
                    State = ResultState.Successfull,
                    Data = _unitOfWork.Repository<Il>().GetByIdAsync(entity.Id).Result.Data,
                };
            }
            catch (Exception ex)
            {
                return new Result<Il>
                {
                    State = ResultState.Fail,
                    Message = "Il güncellenemedi. Hata: " + ex.Message
                };
            }
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            try
            {
                await _unitOfWork.Repository<Il>().Delete(id);
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
                    Message = "Il silinemedi. Hata: " + ex.Message,
                    Data = false
                };
            }
        }
    }
}