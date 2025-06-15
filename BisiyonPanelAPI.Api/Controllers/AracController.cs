using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Interface;
using BisiyonPanelAPI.View;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BisiyonPanelAPI.Domain;

namespace BisiyonPanelAPI.Api
{
    public class AracController : BaseController
    {
        private readonly IAracService _aracService;

        public AracController(IAracService aracService)
        {
            _aracService = aracService;
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

        [HttpPost]
        public async Task<ActionResult<Arac>> Create([FromBody] Arac Arac)
        {
            var createdArac = await _aracService.Insert(Arac);
            return CreatedAtAction(nameof(GetById), new { id = createdArac.Data.Id }, createdArac);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Arac arac)
        {
            if (id != arac.Id)
                return BadRequest("ID eşleşmiyor.");

            var existing = await _aracService.GetByIdAsync(id);
            if (existing.Data == null)
                return NotFound();

            Result<bool> result = await _aracService.Update(existing.Data, arac);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _aracService.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _aracService.Delete(id);
            return NoContent();
        }
    }
}