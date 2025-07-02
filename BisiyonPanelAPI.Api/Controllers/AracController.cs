using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Interface;
using BisiyonPanelAPI.View;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.View.BussinesObjects;
using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace BisiyonPanelAPI.Api
{
    public class AracController : BaseController
    {
        private readonly IAracService _aracService;
        private readonly IAracHareketService _aracHareketService;

        public AracController(IAracService aracService, IAracHareketService aracHareketService)
        {
            _aracService = aracService;
            _aracHareketService = aracHareketService;
        }


        [HttpPost("GetAllAracByFilter")]
        public async Task<IActionResult> GetAllAracByFilter(DataFilterModelView model)
        {
            var result = await _aracService.GetAllAsync(model);
            if (result.Data == null || !result.Data.Any())
                return NotFound("No records found matching the filter criteria.");
            return Ok(result);
        }


        [HttpPost("AracGirisCikis")]
        public async Task<IActionResult> AracGirisCikis([FromBody] AracHareketDto dto)
        {
            var result = await _aracHareketService.LogAracGirisCikisAsync(dto.AracId, dto.AracHareketTipId);
            if (result.Data == null)
                return NotFound("Data is null");
            return Ok(result);
        }

    }
}