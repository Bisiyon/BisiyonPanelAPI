using BisiyonPanelAPI.Interface;
using Microsoft.AspNetCore.Mvc;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Common;
using Mapster;
using BisiyonPanelAPI.View.BussinesObjects;

namespace BisiyonPanelAPI.Api
{
    public class PersonelController : BaseController
    {
        private readonly IPersonelService _personelService;

        public PersonelController(IPersonelService personelService)
        {
            _personelService = personelService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Personel>>> GetAll()
        {
            var result = await _personelService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Personel>> GetById(int id)
        {
            var personel = await _personelService.GetById(id);
            if (personel == null)
                return NotFound();
            return Ok(personel);
        }

        [HttpPost]
        public async Task<ActionResult<Result<Personel>>> Create([FromBody] PersonelBo bo)
        {
            var result = await _personelService.InsertAsync(bo);
            if (result.State == ResultState.Fail)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Result<Personel>>> Update([FromBody] PersonelBo bo)
        {
            var result = await _personelService.UpdateAsync(bo);
            if (result.State == ResultState.Fail)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Personel>> Delete(int id)
        {
            var personel = await _personelService.DeleteAsync(id);
            if (personel == null)
                return NotFound();
            return Ok(personel);
        }

        [HttpPost("GetAllPersonelByFilter")]
        public async Task<IActionResult> GetAllPersonelByFilter(DataFilterModelView model)
        {
            var result = await _personelService.GetAllAsync(model);
            if (result.Data == null || !result.Data.Any())
                return NotFound("No records found matching the fpersonelter criteria.");
            return Ok(result);
        }
    }
}