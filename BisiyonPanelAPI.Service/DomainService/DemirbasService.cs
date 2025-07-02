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
    public class DemirbasService : ServiceBase<Demirbas>, IDemirbasService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DemirbasService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<Demirbas>>> GetAll()
        {
            var items = await _unitOfWork.Repository<Demirbas>().GetAllAsync();
            if (items == null || items.Data == null || !items.Data.Any())
            {
                return new Result<List<Demirbas>>
                {
                    State = ResultState.Fail,
                    Message = "Demirbas Bulunmadı."
                };
            }
            return new Result<List<Demirbas>>
            {
                State = ResultState.Successfull,
                Data = items.Data.ToList()
            };
        }

        public async Task<Result<Demirbas>> GetById(int id)
        {
            var item = await _unitOfWork.Repository<Demirbas>().GetByIdAsync(id);
            if (item == null)
            {
                return new Result<Demirbas>
                {
                    State = ResultState.Fail,
                    Message = "Demirbas bulunamadı."
                };
            }
            return new Result<Demirbas>
            {
                State = ResultState.Successfull,
                Data = item.Data
            };
        }

        public async Task<Result<Demirbas>> InsertAsync(DemirbasBo entity)
        {
            try
            {
                var inserted = await _unitOfWork.Repository<Demirbas>().Insert<DemirbasBo>(entity);
                var addToEntity = await _unitOfWork.SaveChangesAsync();
                return new Result<Demirbas>
                {
                    State = ResultState.Successfull,
                    Data = _unitOfWork.Repository<Demirbas>().GetByIdAsync(inserted.Id).Result.Data,
                };
            }
            catch (Exception ex)
            {
                return new Result<Demirbas>
                {
                    State = ResultState.Fail,
                    Message = "Demirbas eklenemedi. Hata: " + ex.Message
                };
            }
        }

        public async Task<Result<Demirbas>> UpdateAsync(DemirbasBo entity)
        {
            try
            {
                var existing = await _unitOfWork.Repository<Demirbas>().GetByIdAsync<DemirbasBo>(entity.Id);
                if (existing == null)
                {
                    return new Result<Demirbas>
                    {
                        State = ResultState.Fail,
                        Message = "Demirbas bulunamadı."
                    };
                }
                var updated = await _unitOfWork.Repository<Demirbas>().Update<DemirbasBo>(entity);
                var updatedEntity = await _unitOfWork.SaveChangesAsync();
                return new Result<Demirbas>
                {
                    State = ResultState.Successfull,
                    Data = _unitOfWork.Repository<Demirbas>().GetByIdAsync(entity.Id).Result.Data,
                };
            }
            catch (Exception ex)
            {
                return new Result<Demirbas>
                {
                    State = ResultState.Fail,
                    Message = "Demirbas güncellenemedi. Hata: " + ex.Message
                };
            }
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            try
            {
                await _unitOfWork.Repository<Demirbas>().Delete(id);
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
                    Message = "Demirbas silinemedi. Hata: " + ex.Message,
                    Data = false
                };
            }
        }
    }
}
