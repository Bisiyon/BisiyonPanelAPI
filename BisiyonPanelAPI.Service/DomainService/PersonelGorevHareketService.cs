using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Interface;

namespace BisiyonPanelAPI.Service
{
    public class PersonelGorevHareketService : ServiceBase<PersonelGorevHareket>, IPersonelGorevHareketService
    {
        public PersonelGorevHareketService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        
    }
}