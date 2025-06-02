using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Interface;

namespace BisiyonPanelAPI.Service
{
    public class MeskenService : ServiceBase<Mesken>, IMeskenService
    {
        public MeskenService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        
    }
}