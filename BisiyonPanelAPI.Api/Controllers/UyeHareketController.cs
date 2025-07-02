using BisiyonPanelAPI.Interface;
using Microsoft.AspNetCore.Mvc;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.View.BussinesObjects;

namespace BisiyonPanelAPI.Api
{
    public class UyeHareketController : BaseController
    {
        private readonly IUyeHareketService _uyeHareketService;

        public UyeHareketController(IUyeHareketService uyeHareketService)
        {
            _uyeHareketService = uyeHareketService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UyeHareket>>> GetAll()
        {
            var result = await _uyeHareketService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UyeHareket>> GetById(int id)
        {
            var uyeHareket = await _uyeHareketService.GetById(id);
            if (uyeHareket == null)
                return NotFound();
            return Ok(uyeHareket);
        }

        [HttpPost]
        public async Task<ActionResult<Result<UyeHareket>>> Create([FromBody] UyeHareketBo bo)
        {
            var result = await _uyeHareketService.InsertAsync(bo);
            if (result.State == ResultState.Fail)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Result<UyeHareket>>> Update([FromBody] UyeHareketBo bo)
        {
            var result = await _uyeHareketService.UpdateAsync(bo);
            if (result.State == ResultState.Fail)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UyeHareket>> Delete(int id)
        {
            var uyeHareket = await _uyeHareketService.DeleteAsync(id);
            if (uyeHareket == null)
                return NotFound();
            return Ok(uyeHareket);
        }

        [HttpPost("GetAllUyeHareketByFilter")]
        public async Task<IActionResult> GetAllUyeHareketByFilter(DataFilterModelView model)
        {
            var result = await _uyeHareketService.GetAllAsync(model);
            if (result.Data == null || !result.Data.Any())
                return NotFound("No records found matching the filter criteria.");
            return Ok(result);
        }
    }
}