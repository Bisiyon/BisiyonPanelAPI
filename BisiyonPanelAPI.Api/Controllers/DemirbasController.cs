using BisiyonPanelAPI.Interface;
using Microsoft.AspNetCore.Mvc;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.View.BussinesObjects;

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
            var result = await _demirbasService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Demirbas>> GetById(int id)
        {
            var demirbas = await _demirbasService.GetById(id);
            if (demirbas == null)
                return NotFound();
            return Ok(demirbas);
        }

        [HttpPost]
        public async Task<ActionResult<Result<Demirbas>>> Create([FromBody] DemirbasBo bo)
        {
            var result = await _demirbasService.InsertAsync(bo);
            if (result.State == ResultState.Fail)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Result<Demirbas>>> Update([FromBody] DemirbasBo bo)
        {
            var result = await _demirbasService.UpdateAsync(bo);
            if (result.State == ResultState.Fail)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Demirbas>> Delete(int id)
        {
            var demirbas = await _demirbasService.DeleteAsync(id);
            if (demirbas == null)
                return NotFound();
            return Ok(demirbas);
        }

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
