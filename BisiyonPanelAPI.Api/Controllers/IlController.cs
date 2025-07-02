using BisiyonPanelAPI.Interface;
using Microsoft.AspNetCore.Mvc;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Common; 
using Mapster;
using BisiyonPanelAPI.View.BussinesObjects;

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
            var result = await _ilService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Il>> GetById(int id)
        {
            var il = await _ilService.GetById(id);
            if (il == null)
                return NotFound();
            return Ok(il);
        }

        [HttpPost]
        public async Task<ActionResult<Result<Il>>> Create([FromBody] IlBo bo)
        {
            var result = await _ilService.InsertAsync(bo);
            if (result.State == ResultState.Fail)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Result<Il>>> Update([FromBody] IlBo bo)
        {
            var result = await _ilService.UpdateAsync(bo);
            if (result.State == ResultState.Fail)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Il>> Delete(int id)
        {
            var il = await _ilService.DeleteAsync(id);
            if (il == null)
                return NotFound();
            return Ok(il);
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