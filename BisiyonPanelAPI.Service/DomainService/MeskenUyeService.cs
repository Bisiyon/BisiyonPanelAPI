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
    public class MeskenUyeService : ServiceBase<MeskenUye>, IMeskenUyeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MeskenUyeService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<MeskenUye>>> GetAll()
        {
            var items = await _unitOfWork.Repository<MeskenUye>().GetAllAsync();
            if (items == null || items.Data == null || !items.Data.Any())
            {
                return new Result<List<MeskenUye>>
                {
                    State = ResultState.Fail,
                    Message = "MeskenUye Bulunmadı."
                };
            }
            return new Result<List<MeskenUye>>
            {
                State = ResultState.Successfull,
                Data = items.Data.ToList()
            };
        }

        public async Task<Result<MeskenUye>> GetById(int id)
        {
            var item = await _unitOfWork.Repository<MeskenUye>().GetByIdAsync(id);
            if (item == null)
            {
                return new Result<MeskenUye>
                {
                    State = ResultState.Fail,
                    Message = "MeskenUye bulunamadı."
                };
            }
            return new Result<MeskenUye>
            {
                State = ResultState.Successfull,
                Data = item.Data
            };
        }

       public async Task<Result<MeskenUye>> InsertAsync(MeskenUyeBo entity)
        {
            try
            {
                var inserted = await _unitOfWork.Repository<MeskenUye>().Insert<MeskenUyeBo>(entity);

                UyeHareketBo uyeHareketBo = new UyeHareketBo
                {
                    UyeId = entity.UyeId,
                    MeskenId = entity.MeskenId,
                    IslemTarih = DateTime.Now,
                    HareketTipId = (int)Enum_UyeHareketTip.TasinmaGiris
                };

                var insertedUYeHareket = await _unitOfWork.Repository<UyeHareket>().Insert<UyeHareketBo>(uyeHareketBo);
                var addToUyeHareket = await _unitOfWork.SaveChangesAsync();

                return new Result<MeskenUye>
                {
                    State = ResultState.Successfull,
                    Data = _unitOfWork.Repository<MeskenUye>().GetByIdAsync(inserted.Id).Result.Data,
                };
            }
            catch (Exception ex)
            {
                return new Result<MeskenUye>
                {
                    State = ResultState.Fail,
                    Message = "MeskenUye eklenemedi. Hata: " + ex.Message
                };
            }
        }


        public async Task<Result<MeskenUye>> UpdateAsync(MeskenUyeBo entity)
        {
            try
            {
                var existing = await _unitOfWork.Repository<MeskenUye>().GetByIdAsync<MeskenUyeBo>(entity.Id);
                if (existing == null)
                {
                    return new Result<MeskenUye>
                    {
                        State = ResultState.Fail,
                        Message = "MeskenUye bulunamadı."
                    };
                }
                var updated = await _unitOfWork.Repository<MeskenUye>().Update<MeskenUyeBo>(entity);
                var updatedEntity = await _unitOfWork.SaveChangesAsync();
                return new Result<MeskenUye>
                {
                    State = ResultState.Successfull,
                    Data = _unitOfWork.Repository<MeskenUye>().GetByIdAsync(entity.Id).Result.Data,
                };
            }
            catch (Exception ex)
            {
                return new Result<MeskenUye>
                {
                    State = ResultState.Fail,
                    Message = "MeskenUye güncellenemedi. Hata: " + ex.Message
                };
            }
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            try
            {
                await _unitOfWork.Repository<MeskenUye>().Delete(id);
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
                    Message = "MeskenUye silinemedi. Hata: " + ex.Message,
                    Data = false
                };
            }
        }
    }
}