using BisiyonPanelAPI.Interface;
using Microsoft.AspNetCore.Mvc;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.View.BussinesObjects;
using Microsoft.EntityFrameworkCore; 

namespace BisiyonPanelAPI.Api
{
    public class MeskenController : BaseController
    {
        private readonly IMeskenService _meskenService;

        public MeskenController(IMeskenService meskenService)
        {
            _meskenService = meskenService;
        }

         

        [HttpPost("GetAllMeskenByFilter")]
        public async Task<IActionResult> GetAllMeskenByFilter(DataFilterModelView model)
        {
            var result = await _meskenService.GetAllAsync(model);
            if (result.Data == null || !result.Data.Any())
                return NotFound("No records found matching the filter criteria.");
            return Ok(result);
        }
        [HttpPost("GetAllMeskenByDto")]
        public async Task<IActionResult> GetAllMeskenByDto()
        {
            var result = await _meskenService.GetAllAsync<MeskenBo>(x => x.Id > 0, includeFunc: q => q
                .Include(y => y.AidatGrup)
                .Include(y => y.MeskenTipi));

            if (result.Data == null || !result.Data.Any())
                return NotFound("No records found matching the filter criteria.");
            return Ok(result);
        }
        [HttpPost("GetAllMeskenByIdDto")]
        public async Task<IActionResult> GetAllMeskenByIdDto()
        {
            var result = await _meskenService.GetByIdAsync<MeskenBo>(10);

            if (result.Data == null)
                return NotFound("No records found matching the filter criteria.");
            return Ok(result);
        }

    }
}