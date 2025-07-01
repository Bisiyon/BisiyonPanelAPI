using BisiyonPanelAPI.Interface;
using Microsoft.AspNetCore.Mvc;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Common;

namespace BisiyonPanelAPI.Api
{
    public class MeskenTipiController : BaseController
    {
        private readonly IMeskenTipiService _meskenTipiService;

        public MeskenTipiController(IMeskenTipiService meskenTipiService)
        {
            _meskenTipiService = meskenTipiService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MeskenTipi>>> GetAll()
        {
            var result = await _meskenTipiService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MeskenTipi>> GetById(int id)
        {
            var meskenTipi = await _meskenTipiService.GetByIdAsync(id);
            if (meskenTipi == null)
                return NotFound();
            return Ok(meskenTipi);
        }

        // [HttpPost]
        // public async Task<ActionResult<MeskenTipi>> Create([FromBody] MeskenTipi meskenTipi)
        // {
        //     var createdMeskenTipi = await _meskenTipiService.Insert(meskenTipi);
        //     return CreatedAtAction(nameof(GetById), new { id = createdMeskenTipi.Data.Id }, createdMeskenTipi);
        // }

        // [HttpPut("{id}")]
        // public async Task<IActionResult> Update(int id, [FromBody] MeskenTipi meskenTipi)
        // {
        //     if (id != meskenTipi.Id)
        //         return BadRequest("ID eşleşmiyor.");

        //     var existing = await _meskenTipiService.GetByIdAsync(id);
        //     if (existing.Data == null)
        //         return NotFound();

        //     Result<bool> result = await _meskenTipiService.Update(existing.Data, meskenTipi);
        //     return Ok(result);
        // }

        // [HttpDelete("{id}")]
        // public async Task<IActionResult> Delete(int id)
        // {
        //     var existing = await _meskenTipiService.GetByIdAsync(id);
        //     if (existing == null)
        //         return NotFound();

        //     Result<bool> result = await _meskenTipiService.Delete(id);
        //     return Ok(result);
        // }
        
        [HttpPost("GetAllMeskenTipiByFilter")]
        public async Task<IActionResult> GetAllMeskenTipiByFilter(DataFilterModelView model)
        {
            var result = await _meskenTipiService.GetAllAsync(model);
            if (result.Data == null || !result.Data.Any())
                return NotFound("No records found matching the filter criteria.");
            return Ok(result);
        }
    }
}