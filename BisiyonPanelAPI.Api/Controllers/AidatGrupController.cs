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

        [HttpGet]
        public async Task<ActionResult<List<AidatGrup>>> GetAll()
        {
            var result = await _aidatGrupService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AidatGrup>> GetById(int id)
        {
            var AidatGrup = await _aidatGrupService.GetByIdAsync(id);
            if (AidatGrup == null)
                return NotFound();
            return Ok(AidatGrup);
        }

        // [HttpPost]
        // public async Task<ActionResult<AidatGrup>> Create([FromBody] AidatGrup AidatGrup)
        // {
        //     var createdAidatGrup = await _aidatGrupService.Insert(AidatGrup);
        //     return CreatedAtAction(nameof(GetById), new { id = createdAidatGrup.Data.Id }, createdAidatGrup);
        // }

        // [HttpPut("{id}")]
        // public async Task<IActionResult> Update(int id, [FromBody] AidatGrup aidatGrup)
        // {
        //     if (id != aidatGrup.Id)
        //         return BadRequest("ID eşleşmiyor.");

        //     var existing = await _aidatGrupService.GetByIdAsync(id);
        //     if (existing.Data == null)
        //         return NotFound();

        //     Result<bool> result = await _aidatGrupService.Update(existing.Data, aidatGrup);
        //     return Ok(result);
        // }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _aidatGrupService.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _aidatGrupService.Delete(id);
            return NoContent();
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