using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Interface;
using BisiyonPanelAPI.View;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BisiyonPanelAPI.Domain;

namespace BisiyonPanelAPI.Api
{
    public class UyeDurumTipController : BaseController
    {
        private readonly IUyeDurumTipService _uyeDurumTipService;

        public UyeDurumTipController(IUyeDurumTipService uyeDurumTipService)
        {
            _uyeDurumTipService = uyeDurumTipService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UyeDurumTip>>> GetAll()
        {
            var result = await _uyeDurumTipService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UyeDurumTip>> GetById(int id)
        {
            var uyeDurumTip = await _uyeDurumTipService.GetByIdAsync(id);
            if (uyeDurumTip == null)
                return NotFound();
            return Ok(uyeDurumTip);
        }

        [HttpPost]
        public async Task<ActionResult<UyeDurumTip>> Create([FromBody] UyeDurumTip uyeDurumTip)
        {
            var createdUyeDurumTip = await _uyeDurumTipService.Insert(uyeDurumTip);
            return CreatedAtAction(nameof(GetById), new { id = createdUyeDurumTip.Data.Id }, createdUyeDurumTip);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UyeDurumTip uyeDurumTip)
        {
            if (id != uyeDurumTip.Id)
                return BadRequest("ID eşleşmiyor.");

            var existing = await _uyeDurumTipService.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _uyeDurumTipService.Update(uyeDurumTip);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _uyeDurumTipService.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _uyeDurumTipService.Delete(id);
            return NoContent();
        }
    }
}