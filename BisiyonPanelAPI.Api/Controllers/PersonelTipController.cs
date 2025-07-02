using BisiyonPanelAPI.Interface;
using Microsoft.AspNetCore.Mvc;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Common;
using Mapster;
using BisiyonPanelAPI.View.BussinesObjects;

namespace BisiyonPanelAPI.Api
{
    public class PersonelTipController : BaseController
    {
        private readonly IPersonelTipService _personelTipService;

        public PersonelTipController(IPersonelTipService personelTipService)
        {
            _personelTipService = personelTipService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PersonelTip>>> GetAll()
        {
            var result = await _personelTipService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonelTip>> GetById(int id)
        {
            var personelTip = await _personelTipService.GetById(id);
            if (personelTip == null)
                return NotFound();
            return Ok(personelTip);
        }

        [HttpPost]
        public async Task<ActionResult<Result<PersonelTip>>> Create([FromBody] PersonelTipBo bo)
        {
            var result = await _personelTipService.InsertAsync(bo);
            if (result.State == ResultState.Fail)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Result<PersonelTip>>> Update([FromBody] PersonelTipBo bo)
        {
            var result = await _personelTipService.UpdateAsync(bo);
            if (result.State == ResultState.Fail)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PersonelTip>> Delete(int id)
        {
            var personelTip = await _personelTipService.DeleteAsync(id);
            if (personelTip == null)
                return NotFound();
            return Ok(personelTip);
        }

        [HttpPost("GetAllPersonelTipByFilter")]
        public async Task<IActionResult> GetAllPersonelTipByFilter(DataFilterModelView model)
        {
            var result = await _personelTipService.GetAllAsync(model);
            if (result.Data == null || !result.Data.Any())
                return NotFound("No records found matching the fPersonelTipter criteria.");
            return Ok(result);
        }
    }
}