using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Infrastructure;
using BisiyonPanelAPI.Interface;
using BisiyonPanelAPI.View;
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
                    Data = aracHareketEntity.Data,
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