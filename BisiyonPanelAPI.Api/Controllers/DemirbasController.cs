using BisiyonPanelAPI.Interface;
using Microsoft.AspNetCore.Mvc;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Common;

namespace BisiyonPanelAPI.Api
{
    public class DemirbasController : BaseController
    { 
        private readonly IDemirbasService _demirbasService;

        public DemirbasController(IDemirbasService demirbasService)
        {
            _demirbasService = demirbasService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Demirbas>>> GetAll()
        {
            var result = await _demirbasService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Demirbas>> GetById(int id)
        {
            var demirbas = await _demirbasService.GetByIdAsync(id);
            if (demirbas == null)
                return NotFound();
            return Ok(demirbas);
        }

        // [HttpPost]
        // public async Task<ActionResult<Demirbas>> Create([FromBody] Demirbas demirbas)
        // {
        //     var createdDemirbas = await _demirbasService.Insert(demirbas);
        //     return CreatedAtAction(nameof(GetById), new { id = createdDemirbas.Data.Id }, createdDemirbas);
        // }

        // [HttpPut("{id}")]
        // public async Task<IActionResult> Update(int id, [FromBody] Demirbas demirbas)
        // {
        //     if (id != demirbas.Id)
        //         return BadRequest("ID eşleşmiyor.");
        //     var existing = await _demirbasService.GetByIdAsync(id);
        //     if (existing.Data == null)
        //         return NotFound();
        //     Result<bool> result = await _demirbasService.Update(existing.Data, demirbas);
        //     return Ok(result);
        // }

        // [HttpDelete("{id}")]
        // public async Task<IActionResult> Delete(int id)
        // {
        //     var existing = await _demirbasService.GetByIdAsync(id);
        //     if (existing == null)
        //         return NotFound();
        //     Result<bool> result = await _demirbasService.Delete(id);
        //     return Ok(result);
        // }

        [HttpPost("GetAllDemirbasByFilter")]
        public async Task<IActionResult> GetAllDemirbasByFilter(DataFilterModelView model)
        {
            var result = await _demirbasService.GetAllAsync(model);
            if (result.Data == null || !result.Data.Any())
                return NotFound("No records found matching the filter criteria.");
            return Ok(result);
        }
    }
}
