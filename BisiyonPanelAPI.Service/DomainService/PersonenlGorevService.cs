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
    public class PersonelGorevService : ServiceBase<PersonelGorev>, IPersonelGorevService
    {
        public PersonelGorevService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

    }
}