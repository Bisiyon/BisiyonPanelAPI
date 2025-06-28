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
            var result = await _personelTipService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonelTip>> GetById(int id)
        {
            var PersonelTip = await _personelTipService.GetByIdAsync(id);
            if (PersonelTip == null)
                return NotFound();
            return Ok(PersonelTip);
        }

        [HttpPost]
        public async Task<ActionResult<PersonelTip>> Create([FromBody] PersonelTipBo PersonelTip)
        {
            var createdPersonelTip = await _personelTipService.Insert(PersonelTip);
            return CreatedAtAction(nameof(GetById), new { id = createdPersonelTip.Data.Id }, createdPersonelTip);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PersonelTipBo PersonelTip)
        {
            if (id != PersonelTip.Id)
                return BadRequest("ID eþleþmiyor.");

            var existing = await _personelTipService.GetByIdAsync(id);
            if (existing.Data == null)
                return NotFound();

            var oldEntity = existing.Data.Adapt<PersonelTipBo>();

            Result<bool> result = await _personelTipService.Update<PersonelTipBo>(oldEntity, PersonelTip);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _personelTipService.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            Result<bool> result = await _personelTipService.Delete(id);
            return Ok(result);
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