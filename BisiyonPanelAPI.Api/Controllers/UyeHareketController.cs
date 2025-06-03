using BisiyonPanelAPI.Interface;
using Microsoft.AspNetCore.Mvc;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Common;

namespace BisiyonPanelAPI.Api
{
    public class UyeHareketController : BaseController
    {
        private readonly IUyeHareketService _uyeHareketService;

        public UyeHareketController(IUyeHareketService uyeHareketService)
        {
            _uyeHareketService = uyeHareketService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UyeHareket>>> GetAll()
        {
            var result = await _uyeHareketService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UyeHareket>> GetById(int id)
        {
            var uyeHareket = await _uyeHareketService.GetByIdAsync(id);
            if (uyeHareket == null)
                return NotFound();
            return Ok(uyeHareket);
        }

        [HttpPost]
        public async Task<ActionResult<UyeHareket>> Create([FromBody] UyeHareket uyeHareket)
        {
            var createdUyeHareket = await _uyeHareketService.Insert(uyeHareket);
            return CreatedAtAction(nameof(GetById), new { id = createdUyeHareket.Data.Id }, createdUyeHareket);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UyeHareket uyeHareket)
        {
            if (id != uyeHareket.Id)
                return BadRequest("ID eşleşmiyor.");

            var existing = await _uyeHareketService.GetByIdAsync(id);
            if (existing.Data == null)
                return NotFound();

            Result<bool> result = await _uyeHareketService.Update(existing.Data, uyeHareket);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _uyeHareketService.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            Result<bool> result = await _uyeHareketService.Delete(id);
            return Ok(result);
        }
    }
}