using BisiyonPanelAPI.Interface;
using Microsoft.AspNetCore.Mvc;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.View.BussinesObjects;

namespace BisiyonPanelAPI.Api
{
    public class UyeDurumTipController : BaseController
    {
        private readonly IUyeDurumTipService _uyeDurumTipService;

        public UyeDurumTipController(IUyeDurumTipService uyeDurumTipService)
        {
            _uyeDurumTipService = uyeDurumTipService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UyeDurumTip>>> GetAll()
        {
            var result = await _uyeDurumTipService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UyeDurumTip>> GetById(int id)
        {
            var uyeDurumTip = await _uyeDurumTipService.GetById(id);
            if (uyeDurumTip == null)
                return NotFound();
            return Ok(uyeDurumTip);
        }

        [HttpPost]
        public async Task<ActionResult<Result<UyeDurumTip>>> Create([FromBody] UyeDurumTipBo bo)
        {
            var result = await _uyeDurumTipService.InsertAsync(bo);
            if (result.State == ResultState.Fail)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Result<UyeDurumTip>>> Update([FromBody] UyeDurumTipBo bo)
        {
            var result = await _uyeDurumTipService.UpdateAsync(bo);
            if (result.State == ResultState.Fail)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UyeDurumTip>> Delete(int id)
        {
            var uyeDurumTip = await _uyeDurumTipService.DeleteAsync(id);
            if (uyeDurumTip == null)
                return NotFound();
            return Ok(uyeDurumTip);
        }

        [HttpPost("GetAllUyeDurumTipByFilter")]
        public async Task<IActionResult> GetAllUyeDurumTipByFilter(DataFilterModelView model)
        {
            var result = await _uyeDurumTipService.GetAllAsync(model);
            if (result.Data == null || !result.Data.Any())
                return NotFound("No records found matching the filter criteria.");
            return Ok(result);
        }
    }
}