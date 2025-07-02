using BisiyonPanelAPI.Interface;
using Microsoft.AspNetCore.Mvc;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Common;

namespace BisiyonPanelAPI.Api
{
    public class MeskenTipiController : BaseController
    {
        private readonly IMeskenTipiService _meskenTipiService;

        public MeskenTipiController(IMeskenTipiService meskenTipiService)
        {
            _meskenTipiService = meskenTipiService;
        }

         
        
        [HttpPost("GetAllMeskenTipiByFilter")]
        public async Task<IActionResult> GetAllMeskenTipiByFilter(DataFilterModelView model)
        {
            var result = await _meskenTipiService.GetAllAsync(model);
            if (result.Data == null || !result.Data.Any())
                return NotFound("No records found matching the filter criteria.");
            return Ok(result);
        }
    }
}