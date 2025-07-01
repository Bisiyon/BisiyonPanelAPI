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

        [HttpGet]
        public async Task<ActionResult<List<Arac>>> GetAll()
        {
            var result = await _aracService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Arac>> GetById(int id)
        {
            var Arac = await _aracService.GetByIdAsync(id);
            if (Arac == null)
                return NotFound();
            return Ok(Arac);
        }

        // [HttpPost]
        // public async Task<ActionResult<Arac>> Create([FromBody] Arac Arac)
        // {
        //     var createdArac = await _aracService.Insert(Arac);
        //     return CreatedAtAction(nameof(GetById), new { id = createdArac.Data.Id }, createdArac);
        // }

        // [HttpPut("{id}")]
        // public async Task<IActionResult> Update(int id, [FromBody] Arac arac)
        // {
        //     if (id != arac.Id)
        //         return BadRequest("ID eşleşmiyor.");

        //     var existing = await _aracService.GetByIdAsync(id);
        //     if (existing.Data == null)
        //         return NotFound();

        //     Result<bool> result = await _aracService.Update(existing.Data, arac);
        //     return Ok(result);
        // }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _aracService.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _aracService.Delete(id);
            return NoContent();
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