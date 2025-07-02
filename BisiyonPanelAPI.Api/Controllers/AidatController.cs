using BisiyonPanelAPI.Interface;
using Microsoft.AspNetCore.Mvc;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Common;
using Mapster;
using BisiyonPanelAPI.View.BussinesObjects;

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
            var result = await _aidatService.GetAll();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Aidat>> GetById(int id)
        {
            var aidat = await _aidatService.GetById(id);
            if (aidat == null)
                return NotFound();
            return Ok(aidat);
        }

        [HttpPost]
        public async Task<ActionResult<Result<Aidat>>> Create([FromBody] AidatBo bo)
        {
            var result = await _aidatService.InsertAsync(bo);

            if (result.State == ResultState.Fail)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }


        [HttpPut]
        public async Task<ActionResult<Result<Aidat>>> Update([FromBody] AidatBo bo)
        {
            var result = await _aidatService.UpdateAsync(bo);

            if (result.State == ResultState.Fail)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Aidat>> Delete(int id)
        {
            var aidat = await _aidatService.DeleteAsync(id);
            if (aidat == null)
                return NotFound();
            return Ok(aidat);
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