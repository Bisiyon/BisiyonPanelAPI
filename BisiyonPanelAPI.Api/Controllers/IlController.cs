using BisiyonPanelAPI.Interface;
using Microsoft.AspNetCore.Mvc;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Common;

namespace BisiyonPanelAPI.Api
{
    public class IlController : BaseController
    {
        private readonly IIlService _ilService;

        public IlController(IIlService ilService)
        {
            _ilService = ilService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Il>>> GetAll()
        {
            var result = await _ilService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Il>> GetById(int id)
        {
            var il = await _ilService.GetByIdAsync(id);
            if (il == null)
                return NotFound();
            return Ok(il);
        }

        [HttpPost]
        public async Task<ActionResult<Il>> Create([FromBody] Il il)
        {
            var createdIl = await _ilService.Insert(il);
            return CreatedAtAction(nameof(GetById), new { id = createdIl.Data.Id }, createdIl);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Il il)
        {
            if (id != il.Id)
                return BadRequest("ID eşleşmiyor.");

            var existing = await _ilService.GetByIdAsync(id);
            if (existing.Data == null)
                return NotFound();

            Result<bool> result = await _ilService.Update(existing.Data, il);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _ilService.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            Result<bool> result = await _ilService.Delete(id);
            return Ok(result);
        }
                
        [HttpPost("GetAllIlByFilter")]
        public async Task<IActionResult> GetAllIlByFilter(DataFilterModelView model)
        {
            var result = await _ilService.GetAllAsync(model);
            if (result.Data == null || !result.Data.Any())
                return NotFound("No records found matching the filter criteria.");
            return Ok(result);
        }
    }
}