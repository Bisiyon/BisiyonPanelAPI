using BisiyonPanelAPI.Interface;
using Microsoft.AspNetCore.Mvc;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Common; 
using Mapster;
using BisiyonPanelAPI.View.BussinesObjects;

namespace BisiyonPanelAPI.Api
{
    public class IlController : BaseController
    {
        private readonly IIlService _ilService;

        public IlController(IIlService ilService)
        {
            _ilService = ilService;
        }

         

        [HttpPost("GetAllIlByFilter")]
        public async Task<IActionResult> GetAllIlByFilter(DataFilterModelView model)
        {
            var result = await _ilService.GetAllAsync(model);
            if (result.Data == null || !result.Data.Any())
                return NotFound("No records found matching the filter criteria.");
            return Ok(result);
        }
    }
}