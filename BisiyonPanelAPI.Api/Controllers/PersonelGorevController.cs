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
            var result = await _PersonelGorevService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonelGorev>> GetById(int id)
        {
            var PersonelGorev = await _PersonelGorevService.GetByIdAsync(id);
            if (PersonelGorev == null)
                return NotFound();
            return Ok(PersonelGorev);
        }

        [HttpPost]
        public async Task<ActionResult<PersonelGorev>> Create([FromBody] PersonelGorevBo PersonelGorev)
        {
            var createdPersonelGorev = await _PersonelGorevService.Insert(PersonelGorev);
            return CreatedAtAction(nameof(GetById), new { id = createdPersonelGorev.Data.Id }, createdPersonelGorev);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PersonelGorevBo PersonelGorev)
        {
            if (id != PersonelGorev.Id)
                return BadRequest("ID eşleşmiyor.");

            var existing = await _PersonelGorevService.GetByIdAsync(id);
            if (existing.Data == null)
                return NotFound();

            var oldEntity = existing.Data.Adapt<PersonelGorevBo>();

            Result<bool> result = await _PersonelGorevService.Update<PersonelGorevBo>(oldEntity, PersonelGorev);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _PersonelGorevService.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            Result<bool> result = await _PersonelGorevService.Delete(id);
            return Ok(result);
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