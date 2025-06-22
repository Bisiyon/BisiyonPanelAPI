using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Infrastructure;
using BisiyonPanelAPI.Interface;

namespace BisiyonPanelAPI.Service
{
    public class DemirbasService : ServiceBase<Demirbas>, IDemirbasService
    {
        public DemirbasService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
