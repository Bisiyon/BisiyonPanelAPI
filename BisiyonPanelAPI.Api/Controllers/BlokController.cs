using BisiyonPanelAPI.Interface;
using Microsoft.AspNetCore.Mvc;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.View;
using Microsoft.AspNetCore.Authorization;

namespace BisiyonPanelAPI.Api
{
    public class BlokController : BaseController
    {
        private readonly IBlokService _blokService;
        private readonly IMeskenService _meskenService;

        public BlokController(IBlokService blokService, IMeskenService meskenService)
        {
            _blokService = blokService;
            _meskenService = meskenService;
        }

         

        [HttpPost("GetAllBlokByFilter")]
        public async Task<IActionResult> GetAllBlokByFilter(DataFilterModelView model)
        {
            var result = await _blokService.GetAllAsync(model);
            if (result.Data == null || !result.Data.Any())
                return NotFound("No records found matching the filter criteria.");
            return Ok(result);
        }

        [HttpPost("CreateNewBlokWithMesken")]
        public async Task<IActionResult> CreateNewBlokWithMesken([FromBody] CreateNewBlokWithMeskenRequestDto dto)
        {
            var result = await _blokService.CreateBlokWithMesken(dto);
            if (result.Data == null)
                return NotFound("Data is null");
            return Ok(result);
        }
    }
}