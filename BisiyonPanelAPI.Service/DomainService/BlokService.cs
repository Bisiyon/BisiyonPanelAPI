using System.IO.Compression;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Infrastructure;
using BisiyonPanelAPI.Interface;
using BisiyonPanelAPI.View;
using BisiyonPanelAPI.View.BussinesObjects;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BisiyonPanelAPI.Service
{
    public class BlokService : ServiceBase<Blok>, IBlokService
    {
        private readonly IServiceBase<Blok> Current;
        private readonly IMeskenService _meskenService;
        private readonly BisiyonAppContext _appContext;
        private readonly IUnitOfWork _unitOfWork;

        public BlokService(IUnitOfWork unitOfWork, BisiyonAppContext appContext, IServiceBase<Blok> Current, IMeskenService meskenService) : base(unitOfWork)
        {
            this.Current = Current;
            _appContext = appContext;
            _meskenService = meskenService;
            _unitOfWork = unitOfWork;
        }


        public async Task<Result<BlokBo>> CreateBlokWithMesken(CreateNewBlokWithMeskenRequestDto dto)
        {
            var result = new Result<BlokBo>() { State = ResultState.Fail };
            try
            {
                 var blok =await _unitOfWork.Repository<Blok>().Insert<BlokBo>(dto.Blok);
    
                var addToBlok =await _unitOfWork.SaveChangesAsync();
                if (addToBlok.IsSuccessfull)
                {
                    result = await _unitOfWork.Repository<Blok>().GetByIdAsync<BlokBo>(blok.Id);
                 }
            }
            catch (System.Exception ex )
            {
                
            }
           
            return result;
        }
    }
}