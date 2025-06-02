using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Interface;

namespace BisiyonPanelAPI.Service
{
    public class UyeHareketService : ServiceBase<UyeHareket>, IUyeHareketService
    {
        public UyeHareketService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        
    }
}