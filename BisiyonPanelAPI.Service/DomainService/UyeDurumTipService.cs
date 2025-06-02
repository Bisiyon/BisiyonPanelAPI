using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Interface;

namespace BisiyonPanelAPI.Service
{
    public class UyeDurumTipService : ServiceBase<UyeDurumTip>, IUyeDurumTipService
    {
        public UyeDurumTipService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }


    }
}
