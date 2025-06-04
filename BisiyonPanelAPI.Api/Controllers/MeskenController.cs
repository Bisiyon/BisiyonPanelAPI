using BisiyonPanelAPI.Interface;
using Microsoft.AspNetCore.Mvc;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Common;

namespace BisiyonPanelAPI.Api
{
    public class MeskenController : BaseController
    {
        private readonly IMeskenService _meskenService;

        public MeskenController(IMeskenService meskenService)
        {
            _meskenService = meskenService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Mesken>>> GetAll()
        {
            var result = await _meskenService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Mesken>> GetById(int id)
        {
            var mesken = await _meskenService.GetByIdAsync(id);
            if (mesken == null)
                return NotFound();
            return Ok(mesken);
        }

        [HttpPost]
        public async Task<ActionResult<Mesken>> Create([FromBody] Mesken mesken)
        {
            var createdMesken = await _meskenService.Insert(mesken);
            return CreatedAtAction(nameof(GetById), new { id = createdMesken.Data.Id }, createdMesken);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Mesken mesken)
        {
            if (id != mesken.Id)
                return BadRequest("ID eşleşmiyor.");

            var existing = await _meskenService.GetByIdAsync(id);
            if (existing.Data == null)
                return NotFound();

            Result<bool> result = await _meskenService.Update(existing.Data, mesken);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _meskenService.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            Result<bool> result = await _meskenService.Delete(id);
            return Ok(result);
        }
    }
}