using BisiyonPanelAPI.Interface;
using Microsoft.AspNetCore.Mvc;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Common;
using Mapster;
using BisiyonPanelAPI.View.BussinesObjects;

namespace BisiyonPanelAPI.Api
{
    public class PersonelGorevController : BaseController
    {
        private readonly IPersonelGorevService _PersonelGorevService;

        public PersonelGorevController(IPersonelGorevService PersonelGorevService)
        {
            _PersonelGorevService = PersonelGorevService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PersonelGorev>>> GetAll()
        {
            var result = await _PersonelGorevService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonelGorev>> GetById(int id)
        {
            var personelGorev = await _PersonelGorevService.GetById(id);
            if (personelGorev == null)
                return NotFound();
            return Ok(personelGorev);
        }

        [HttpPost]
        public async Task<ActionResult<Result<PersonelGorev>>> Create([FromBody] PersonelGorevBo bo)
        {
            var result = await _PersonelGorevService.InsertAsync(bo);
            if (result.State == ResultState.Fail)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Result<PersonelGorev>>> Update([FromBody] PersonelGorevBo bo)
        {
            var result = await _PersonelGorevService.UpdateAsync(bo);
            if (result.State == ResultState.Fail)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PersonelGorev>> Delete(int id)
        {
            var personelGorev = await _PersonelGorevService.DeleteAsync(id);
            if (personelGorev == null)
                return NotFound();
            return Ok(personelGorev);
        }

        [HttpPost("GetAllPersonelGorevByFilter")]
        public async Task<IActionResult> GetAllPersonelGorevByFilter(DataFilterModelView model)
        {
            var result = await _PersonelGorevService.GetAllAsync(model);
            if (result.Data == null || !result.Data.Any())
                return NotFound("No records found matching the fPersonelGorevter criteria.");
            return Ok(result);
        }
    }
}