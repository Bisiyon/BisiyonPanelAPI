using BisiyonPanelAPI.Interface;
using Microsoft.AspNetCore.Mvc;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.View.BussinesObjects;

namespace BisiyonPanelAPI.Api
{
    public class UyeController : BaseController
    {
        private readonly IUyeService _uyeService;

        public UyeController(IUyeService uyeService)
        {
            _uyeService = uyeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Uye>>> GetAll()
        {
            var result = await _uyeService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Uye>> GetById(int id)
        {
            var uye = await _uyeService.GetById(id);
            if (uye == null)
                return NotFound();
            return Ok(uye);
        }

        [HttpPost]
        public async Task<ActionResult<Result<Uye>>> Create([FromBody] UyeBo bo)
        {
            var result = await _uyeService.InsertAsync(bo);
            if (result.State == ResultState.Fail)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Result<Uye>>> Update([FromBody] UyeBo bo)
        {
            var result = await _uyeService.UpdateAsync(bo);
            if (result.State == ResultState.Fail)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Uye>> Delete(int id)
        {
            var uye = await _uyeService.DeleteAsync(id);
            if (uye == null)
                return NotFound();
            return Ok(uye);
        }

        [HttpPost("GetAllUyeByFilter")]
        public async Task<IActionResult> GetAllUyeByFilter(DataFilterModelView model)
        {
            var result = await _uyeService.GetAllAsync(model);
            if (result.Data == null || !result.Data.Any())
                return NotFound("No records found matching the filter criteria.");
            return Ok(result);
        }
    }
}