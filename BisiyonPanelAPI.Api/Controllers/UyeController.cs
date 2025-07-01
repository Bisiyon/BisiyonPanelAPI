using BisiyonPanelAPI.Interface;
using Microsoft.AspNetCore.Mvc;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Common;

namespace BisiyonPanelAPI.Api
{
    public class UyeController : BaseController
    {
        private readonly IUyeService _uyeService;

        public UyeController(IUyeService uyeService)
        {
            _uyeService = uyeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Uye>>> GetAll()
        {
            var result = await _uyeService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Uye>> GetById(int id)
        {
            var uye = await _uyeService.GetByIdAsync(id);
            if (uye == null)
                return NotFound();
            return Ok(uye);
        }

        // [HttpPost]
        // public async Task<ActionResult<Uye>> Create([FromBody] Uye uye)
        // {
        //     var createdUye = await _uyeService.Insert(uye);
        //     return CreatedAtAction(nameof(GetById), new { id = createdUye.Data.Id }, createdUye);
        // }

        // [HttpPut("{id}")]
        // public async Task<IActionResult> Update(int id, [FromBody] Uye uye)
        // {
        //     if (id != uye.Id)
        //         return BadRequest("ID eşleşmiyor.");

        //     var existing = await _uyeService.GetByIdAsync(id);
        //     if (existing.Data == null)
        //         return NotFound();

        //     Result<bool> result = await _uyeService.Update(existing.Data, uye);
        //     return Ok(result);
        // }

        // [HttpDelete("{id}")]
        // public async Task<IActionResult> Delete(int id)
        // {
        //     var existing = await _uyeService.GetByIdAsync(id);
        //     if (existing == null)
        //         return NotFound();

        //     Result<bool> result = await _uyeService.Delete(id);
        //     return Ok(result);
        // }

        [HttpPost("GetAllUyeByFilter")]
        public async Task<IActionResult> GetAllUyeByFilter(DataFilterModelView model)
        {
            var result = await _uyeService.GetAllAsync(model);
            if (result.Data == null || !result.Data.Any())
                return NotFound("No records found matching the filter criteria.");
            return Ok(result);
        }
    }
}