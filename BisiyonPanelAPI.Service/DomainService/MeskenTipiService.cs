using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Interface;

namespace BisiyonPanelAPI.Service
{
    public class MeskenTipiService : ServiceBase<MeskenTipi>, IMeskenTipiService
    {
        public MeskenTipiService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        
    }
}