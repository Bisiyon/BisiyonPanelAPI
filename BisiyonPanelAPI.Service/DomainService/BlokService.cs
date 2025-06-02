using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Interface;

namespace BisiyonPanelAPI.Service
{
    public class BlokService : ServiceBase<Blok>, IBlokService
    {
        public BlokService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        
    }
}