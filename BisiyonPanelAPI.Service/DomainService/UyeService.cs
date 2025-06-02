using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Interface;

namespace BisiyonPanelAPI.Service
{
    public class UyeService : ServiceBase<Uye>, IUyeService
    {
        public UyeService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        
    }
}