using BisiyonPanelAPI.Interface;
using Microsoft.AspNetCore.Mvc;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Common;

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

        // [HttpPut("{id}")]
        // public async Task<IActionResult> Update(int id, [FromBody] UyeDurumTip uyeDurumTip)
        // {
        //     if (id != uyeDurumTip.Id)
        //         return BadRequest("ID eşleşmiyor.");

        //     var existing = await _uyeDurumTipService.GetByIdAsync(id);
        //     if (existing.Data == null)
        //         return NotFound();

        //     Result<bool> result = await _uyeDurumTipService.Update(existing.Data, uyeDurumTip);
        //     return Ok(result);
        // }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _uyeDurumTipService.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            Result<bool> result = await _uyeDurumTipService.Delete(id);
            return Ok(result);
        }
    }
}