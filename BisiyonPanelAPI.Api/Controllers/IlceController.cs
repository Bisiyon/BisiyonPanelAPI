using BisiyonPanelAPI.Interface;
using Microsoft.AspNetCore.Mvc;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Common;

namespace BisiyonPanelAPI.Api
{
    public class IlceController : BaseController
    {
        private readonly IIlceService _ilceService;

        public IlceController(IIlceService ilceService)
        {
            _ilceService = ilceService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Ilce>>> GetAll()
        {
            var result = await _ilceService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ilce>> GetById(int id)
        {
            var ilce = await _ilceService.GetByIdAsync(id);
            if (ilce == null)
                return NotFound();
            return Ok(ilce);
        }

        [HttpPost]
        public async Task<ActionResult<Ilce>> Create([FromBody] Ilce ilce)
        {
            var createdIlce = await _ilceService.Insert(ilce);
            return CreatedAtAction(nameof(GetById), new { id = createdIlce.Data.Id }, createdIlce);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Ilce ilce)
        {
            if (id != ilce.Id)
                return BadRequest("ID eşleşmiyor.");

            var existing = await _ilceService.GetByIdAsync(id);
            if (existing.Data == null)
                return NotFound();

            Result<bool> result = await _ilceService.Update(existing.Data, ilce);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _ilceService.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            Result<bool> result = await _ilceService.Delete(id);
            return Ok(result);
        }
        
        [HttpPost("GetAllIlceByFilter")]
        public async Task<IActionResult> GetAllIlceByFilter(DataFilterModelView model)
        {
            var result = await _ilceService.GetAllAsync(model);
            if (result.Data == null || !result.Data.Any())
                return NotFound("No records found matching the filter criteria.");
            return Ok(result);
        }
    }
}