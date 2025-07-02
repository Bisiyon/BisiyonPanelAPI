using BisiyonPanelAPI.Interface;
using Microsoft.AspNetCore.Mvc;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Common;

namespace BisiyonPanelAPI.Api
{
    public class IlceController : BaseController
    {
        private readonly IIlceService _ilceService;

        public IlceController(IIlceService ilceService)
        {
            _ilceService = ilceService;
        }

         
        
        [HttpPost("GetAllIlceByFilter")]
        public async Task<IActionResult> GetAllIlceByFilter(DataFilterModelView model)
        {
            var result = await _ilceService.GetAllAsync(model);
            if (result.Data == null || !result.Data.Any())
                return NotFound("No records found matching the filter criteria.");
            return Ok(result);
        }
    }
}