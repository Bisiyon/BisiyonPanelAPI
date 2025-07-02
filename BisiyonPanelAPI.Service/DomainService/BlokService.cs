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




        public async Task<Result<List<Blok>>> GetAll()
        {
            var items = await _unitOfWork.Repository<Blok>().GetAllAsync();
            if (items == null || items.Data == null || !items.Data.Any())
            {
                return new Result<List<Blok>>
                {
                    State = ResultState.Fail,
                    Message = "Blok Bulunmadı."
                };
            }
            return new Result<List<Blok>>
            {
                State = ResultState.Successfull,
                Data = items.Data.ToList()
            };
        }

        public async Task<Result<Blok>> GetById(int id)
        {
            var item = await _unitOfWork.Repository<Blok>().GetByIdAsync(id);
            if (item == null)
            {
                return new Result<Blok>
                {
                    State = ResultState.Fail,
                    Message = "Blok bulunamadı."
                };
            }
            return new Result<Blok>
            {
                State = ResultState.Successfull,
                Data = item.Data
            };
        }

        public async Task<Result<Blok>> InsertAsync(BlokBo entity)
        {
            try
            {
                var inserted = await _unitOfWork.Repository<Blok>().Insert<BlokBo>(entity);
                var addToEntity = await _unitOfWork.SaveChangesAsync();
                return new Result<Blok>
                {
                    State = ResultState.Successfull,
                    Data = _unitOfWork.Repository<Blok>().GetByIdAsync(inserted.Id).Result.Data,
                };
            }
            catch (Exception ex)
            {
                return new Result<Blok>
                {
                    State = ResultState.Fail,
                    Message = "Blok eklenemedi. Hata: " + ex.Message
                };
            }
        }

        public async Task<Result<Blok>> UpdateAsync(BlokBo entity)
        {
            try
            {
                var existing = await _unitOfWork.Repository<Blok>().GetByIdAsync<BlokBo>(entity.Id);
                if (existing == null)
                {
                    return new Result<Blok>
                    {
                        State = ResultState.Fail,
                        Message = "Blok bulunamadı."
                    };
                }
                var updated = await _unitOfWork.Repository<Blok>().Update<BlokBo>(entity);
                var updatedEntity = await _unitOfWork.SaveChangesAsync();
                return new Result<Blok>
                {
                    State = ResultState.Successfull,
                    Data = _unitOfWork.Repository<Blok>().GetByIdAsync(entity.Id).Result.Data,
                };
            }
            catch (Exception ex)
            {
                return new Result<Blok>
                {
                    State = ResultState.Fail,
                    Message = "Blok güncellenemedi. Hata: " + ex.Message
                };
            }
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            try
            {
                await _unitOfWork.Repository<Blok>().Delete(id);
                await _unitOfWork.SaveChangesAsync();
                return new Result<bool>
                {
                    State = ResultState.Successfull,
                    Data = true
                };
            }
            catch (Exception ex)
            {
                return new Result<bool>
                {
                    State = ResultState.Fail,
                    Message = "Blok silinemedi. Hata: " + ex.Message,
                    Data = false
                };
            }
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