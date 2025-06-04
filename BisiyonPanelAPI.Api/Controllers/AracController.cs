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
        private readonly IAracService _AracService;

        public AracController(IAracService AracService)
        {
            _AracService = AracService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Arac>>> GetAll()
        {
            var result = await _AracService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Arac>> GetById(int id)
        {
            var Arac = await _AracService.GetByIdAsync(id);
            if (Arac == null)
                return NotFound();
            return Ok(Arac);
        }

        [HttpPost]
        public async Task<ActionResult<Arac>> Create([FromBody] Arac Arac)
        {
            var createdArac = await _AracService.Insert(Arac);
            return CreatedAtAction(nameof(GetById), new { id = createdArac.Data.Id }, createdArac);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Arac Arac)
        {
            if (id != Arac.Id)
                return BadRequest("ID eşleşmiyor.");

            var existing = await _AracService.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _AracService.Update(Arac);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _AracService.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _AracService.Delete(id);
            return NoContent();
        }
    }
}