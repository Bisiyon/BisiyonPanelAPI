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
            var result = await _personelService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Personel>> GetById(int id)
        {
            var personel = await _personelService.GetByIdAsync(id);
            if (personel == null)
                return NotFound();
            return Ok(personel);
        }

        [HttpPost]
        public async Task<ActionResult<Personel>> Create([FromBody] PersonelBo personel)
        {
            var createdPersonel = await _personelService.Insert(personel);
            return CreatedAtAction(nameof(GetById), new { id = createdPersonel.Data.Id }, createdPersonel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PersonelBo personel)
        {
            if (id != personel.Id)
                return BadRequest("ID eşleşmiyor.");

            var existing = await _personelService.GetByIdAsync(id);
            if (existing.Data == null)
                return NotFound();

            var oldEntity = existing.Data.Adapt<PersonelBo>();

            Result<bool> result = await _personelService.Update<PersonelBo>(oldEntity, personel);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _personelService.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            Result<bool> result = await _personelService.Delete(id);
            return Ok(result);
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