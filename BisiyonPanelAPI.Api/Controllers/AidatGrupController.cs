using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Interface;
using BisiyonPanelAPI.View;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.View.BussinesObjects;

namespace BisiyonPanelAPI.Api
{
    public class AidatGrupController : BaseController
    {
        private readonly IAidatGrupService _aidatGrupService;

        public AidatGrupController(IAidatGrupService aidatGrupService)
        {
            _aidatGrupService = aidatGrupService;
        }

        [HttpGet]
        public async Task<ActionResult<List<AidatGrup>>> GetAll()
        {
            var result = await _aidatGrupService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AidatGrup>> GetById(int id)
        {
            var aidatGrup = await _aidatGrupService.GetById(id);
            if (aidatGrup == null)
                return NotFound();
            return Ok(aidatGrup);
        }

        [HttpPost]
        public async Task<ActionResult<Result<AidatGrup>>> Create([FromBody] AidatGrupBo bo)
        {
            var result = await _aidatGrupService.InsertAsync(bo);
            if (result.State == ResultState.Fail)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Result<AidatGrup>>> Update([FromBody] AidatGrupBo bo)
        {
            var result = await _aidatGrupService.UpdateAsync(bo);
            if (result.State == ResultState.Fail)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AidatGrup>> Delete(int id)
        {
            var aidatGrup = await _aidatGrupService.DeleteAsync(id);
            if (aidatGrup == null)
                return NotFound();
            return Ok(aidatGrup);
        }

        [HttpPost("GetAllAidatGrupByFilter")]
        public async Task<IActionResult> GetAllAidatGrupByFilter(DataFilterModelView model)
        {
            var result = await _aidatGrupService.GetAllAsync(model);
            if (result.Data == null || !result.Data.Any())
                return NotFound("No records found matching the filter criteria.");
            return Ok(result);
        }
    }
}