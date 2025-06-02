using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Interface;
using BisiyonPanelAPI.View;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BisiyonPanelAPI.Domain;

namespace BisiyonPanelAPI.Api
{
    public class MeskenTipiController : BaseController
    {
        private readonly IMeskenTipiService _meskenTipiService;

        public MeskenTipiController(IMeskenTipiService meskenTipiService)
        {
            _meskenTipiService = meskenTipiService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MeskenTipi>>> GetAll()
        {
            var result = await _meskenTipiService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MeskenTipi>> GetById(int id)
        {
            var meskenTipi = await _meskenTipiService.GetByIdAsync(id);
            if (meskenTipi == null)
                return NotFound();
            return Ok(meskenTipi);
        }

        [HttpPost]
        public async Task<ActionResult<MeskenTipi>> Create([FromBody] MeskenTipi meskenTipi)
        {
            var createdMeskenTipi = await _meskenTipiService.Insert(meskenTipi);
            return CreatedAtAction(nameof(GetById), new { id = createdMeskenTipi.Data.Id }, createdMeskenTipi);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MeskenTipi meskenTipi)
        {
            if (id != meskenTipi.Id)
                return BadRequest("ID eşleşmiyor.");

            var existing = await _meskenTipiService.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _meskenTipiService.Update(meskenTipi);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _meskenTipiService.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _meskenTipiService.Delete(id);
            return NoContent();
        }
    }
}