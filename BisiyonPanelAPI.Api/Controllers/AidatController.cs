using BisiyonPanelAPI.Interface;
using Microsoft.AspNetCore.Mvc;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.CommonObjects;
using BisiyonPanelAPI.View.UserView;
using Mapster;

namespace BisiyonPanelAPI.Api
{
    public class AidatController : BaseController
    {
        private readonly IAidatService _aidatService;

        public AidatController(IAidatService aidatService)
        {
            _aidatService = aidatService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Aidat>>> GetAll()
        {
            var result = await _aidatService.GetAllAsync();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Aidat>> GetById(int id)
        {
            var aidat = await _aidatService.GetByIdAsync(id);
            if (aidat == null)
                return NotFound();
            return Ok(aidat);
        }

        [HttpPost]
        public async Task<ActionResult<Aidat>> Create([FromBody] AidatView aidat)
        {
            var createdAidat = await _aidatService.Insert(aidat);
            return CreatedAtAction(nameof(GetById), new { id = createdAidat.Data.Id }, createdAidat);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AidatView aidat)
        {
            if (id != aidat.Id)
                return BadRequest("ID eşleşmiyor.");

            var existing = await _aidatService.GetByIdAsync(id);
            if (existing.Data == null)
                return NotFound();

            var oldEntity = existing.Data.Adapt<AidatView>();


            Result<bool> result = await _aidatService.Update<AidatView>(oldEntity, aidat);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _aidatService.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            Result<bool> result = await _aidatService.Delete(id);
            return Ok(result);
        }
        
        [HttpPost("GetAllAidatByFilter")]
        public async Task<IActionResult> GetAllAidatByFilter(DataFilterModelView model)
        {
            var result = await _aidatService.GetAllAsync(model);
            if (result.Data == null || !result.Data.Any())
                return NotFound("No records found matching the filter criteria.");
            return Ok(result);
        }
    }
}