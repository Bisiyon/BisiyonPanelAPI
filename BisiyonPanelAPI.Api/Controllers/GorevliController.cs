using BisiyonPanelAPI.Interface;
using Microsoft.AspNetCore.Mvc;
using BisiyonPanelAPI.Domain;

namespace BisiyonPanelAPI.Api
{
    public class GorevliController : BaseController
    {
        private readonly IGorevliService _gorevliService;

        public GorevliController(IGorevliService gorevliService)
        {
            _gorevliService = gorevliService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Gorevli>>> GetAll()
        {
            var result = await _gorevliService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Gorevli>> GetById(int id)
        {
            var gorevli = await _gorevliService.GetByIdAsync(id);
            if (gorevli == null)
                return NotFound();
            return Ok(gorevli);
        }

        [HttpPost]
        public async Task<ActionResult<Gorevli>> Create([FromBody] Gorevli gorevli)
        {
            var createdGorevli = await _gorevliService.Insert(gorevli);
            return CreatedAtAction(nameof(GetById), new { id = createdGorevli.Data.Id }, createdGorevli);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Gorevli gorevli)
        {
            if (id != gorevli.Id)
                return BadRequest("ID eşleşmiyor.");

            var existing = await _gorevliService.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _gorevliService.Update(gorevli);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _gorevliService.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _gorevliService.Delete(id);
            return NoContent();
        }
    }
}