using BisiyonPanelAPI.Interface;
using Microsoft.AspNetCore.Mvc;
using BisiyonPanelAPI.Domain;

namespace BisiyonPanelAPI.Api
{
    public class AidatController : BaseController
    {
        private readonly IAidatService _aidatService;

        public AidatController(IAidatService aidatService)
        {
            _aidatService = aidatService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Aidat>>> GetAll()
        {
            var result = await _aidatService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Aidat>> GetById(int id)
        {
            var aidat = await _aidatService.GetByIdAsync(id);
            if (aidat == null)
                return NotFound();
            return Ok(aidat);
        }

        [HttpPost]
        public async Task<ActionResult<Aidat>> Create([FromBody] Aidat aidat)
        {
            var createdAidat = await _aidatService.Insert(aidat);
            return CreatedAtAction(nameof(GetById), new { id = createdAidat.Data.Id }, createdAidat);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Aidat aidat)
        {
            if (id != aidat.Id)
                return BadRequest("ID eşleşmiyor.");

            var existing = await _aidatService.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _aidatService.Update(aidat);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _aidatService.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _aidatService.Delete(id);
            return NoContent();
        }
    }
}