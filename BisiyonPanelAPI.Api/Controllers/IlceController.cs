using BisiyonPanelAPI.Interface;
using Microsoft.AspNetCore.Mvc;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.View.BussinesObjects;

namespace BisiyonPanelAPI.Api
{
    public class IlceController : BaseController
    {
        private readonly IIlceService _ilceService;

        public IlceController(IIlceService ilceService)
        {
            _ilceService = ilceService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Ilce>>> GetAll()
        {
            var result = await _ilceService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ilce>> GetById(int id)
        {
            var ilce = await _ilceService.GetById(id);
            if (ilce == null)
                return NotFound();
            return Ok(ilce);
        }

        [HttpPost]
        public async Task<ActionResult<Result<Ilce>>> Create([FromBody] IlceBo bo)
        {
            var result = await _ilceService.InsertAsync(bo);
            if (result.State == ResultState.Fail)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Result<Ilce>>> Update([FromBody] IlceBo bo)
        {
            var result = await _ilceService.UpdateAsync(bo);
            if (result.State == ResultState.Fail)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Ilce>> Delete(int id)
        {
            var ilce = await _ilceService.DeleteAsync(id);
            if (ilce == null)
                return NotFound();
            return Ok(ilce);
        }

        [HttpPost("GetAllIlceByFilter")]
        public async Task<IActionResult> GetAllIlceByFilter(DataFilterModelView model)
        {
            var result = await _ilceService.GetAllAsync(model);
            if (result.Data == null || !result.Data.Any())
                return NotFound("No records found matching the filter criteria.");
            return Ok(result);
        }
    }
}