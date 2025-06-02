using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Interface;

namespace BisiyonPanelAPI.Service
{
    public class GorevliService : ServiceBase<Gorevli>, IGorevliService
    {
        public GorevliService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        
    }
}