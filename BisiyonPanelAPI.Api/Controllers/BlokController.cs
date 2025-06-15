using BisiyonPanelAPI.Interface;
using Microsoft.AspNetCore.Mvc;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Common;

namespace BisiyonPanelAPI.Api
{
    public class BlokController : BaseController
    {
        private readonly IBlokService _blokService;

        public BlokController(IBlokService blokService)
        {
            _blokService = blokService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Blok>>> GetAll()
        {
            var result = await _blokService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Blok>> GetById(int id)
        {
            var blok = await _blokService.GetByIdAsync(id);
            if (blok == null)
                return NotFound();
            return Ok(blok);
        }

        [HttpPost]
        public async Task<ActionResult<Blok>> Create([FromBody] Blok blok)
        {
            var createdBlok = await _blokService.Insert(blok);
            return CreatedAtAction(nameof(GetById), new { id = createdBlok.Data.Id }, createdBlok);
        }

        // [HttpPut("{id}")]
        // public async Task<IActionResult> Update(int id, [FromBody] Blok blok)
        // {
        //     if (id != blok.Id)
        //         return BadRequest("ID eşleşmiyor.");

        //     var existing = await _blokService.GetByIdAsync(id);
        //     if (existing.Data == null)
        //         return NotFound();

        //     Result<bool> result = await _blokService.Update(existing.Data, blok);
        //     return Ok(result);
        // }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _blokService.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            Result<bool> result = await _blokService.Delete(id);
            return Ok(result);
        }
    }
}