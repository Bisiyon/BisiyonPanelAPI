using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Interface;
using BisiyonPanelAPI.View;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BisiyonPanelAPI.Domain;

namespace BisiyonPanelAPI.Api
{
    public class AidatGrupController : BaseController
    {
        private readonly IAidatGrupService _aidatGrupService;

        public AidatGrupController(IAidatGrupService aidatGrupService)
        {
            _aidatGrupService = aidatGrupService;
        }

         

        [HttpPost("GetAllAidatGrupByFilter")]
        public async Task<IActionResult> GetAllAidatGrupByFilter(DataFilterModelView model)
        {
            var result = await _aidatGrupService.GetAllAsync(model);
            if (result.Data == null || !result.Data.Any())
                return NotFound("No records found matching the filter criteria.");
            return Ok(result);
        }
    }
}