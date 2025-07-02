using BisiyonPanelAPI.Interface;
using Microsoft.AspNetCore.Mvc;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Common;

namespace BisiyonPanelAPI.Api
{
    public class DemirbasController : BaseController
    { 
        private readonly IDemirbasService _demirbasService;

        public DemirbasController(IDemirbasService demirbasService)
        {
            _demirbasService = demirbasService;
        }

         

        [HttpPost("GetAllDemirbasByFilter")]
        public async Task<IActionResult> GetAllDemirbasByFilter(DataFilterModelView model)
        {
            var result = await _demirbasService.GetAllAsync(model);
            if (result.Data == null || !result.Data.Any())
                return NotFound("No records found matching the filter criteria.");
            return Ok(result);
        }
    }
}
