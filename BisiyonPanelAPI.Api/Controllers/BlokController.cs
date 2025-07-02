using BisiyonPanelAPI.Interface;
using Microsoft.AspNetCore.Mvc;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.View;
using Microsoft.AspNetCore.Authorization;

namespace BisiyonPanelAPI.Api
{
    public class BlokController : BaseController
    {
        private readonly IBlokService _blokService;
        private readonly IMeskenService _meskenService;

        public BlokController(IBlokService blokService, IMeskenService meskenService)
        {
            _blokService = blokService;
            _meskenService = meskenService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Blok>>> GetAll()
        {
            var result = await _blokService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Blok>> GetById(int id)
        {
            var blok = await _blokService.GetByIdAsync(id);
            if (blok == null)
                return NotFound();
            return Ok(blok);
        }

        [HttpPost]
        public async Task<ActionResult<Blok>> Create([FromBody] Blok blok)
        {
            var createdBlok = await _blokService.Insert(blok);
            return CreatedAtAction(nameof(GetById), new { id = createdBlok.Id }, createdBlok);
        }

        // [HttpPut("{id}")]
        // public async Task<IActionResult> Update(int id, [FromBody] Blok blok)
        // {
        //     if (id != blok.Id)
        //         return BadRequest("ID eşleşmiyor.");

        //     var hasMesken = _meskenService.GetAllAsync(g => g.BlokId == blok.Id);

        //     if (hasMesken.Result.Data != null)
        //     {
        //         return BadRequest(new Result<bool>
        //         {
        //             State = ResultState.Fail,
        //             Message = "Kayıtlı mesken kaydı bulunmaktadır. Güncelleme işlemi yapılamaz."
        //         });
        //     }


        //     var existing = await _blokService.GetByIdAsync(id);
        //     if (existing.Data == null)
        //         return NotFound();

        //     Result<bool> result = await _blokService.Update(existing.Data blok);
        //     return Ok(result);
        // }

        // [HttpDelete("{id}")]
        // public async Task<IActionResult> Delete(int id)
        // {
        //     var hasMesken = _meskenService.GetAllAsync(g => g.BlokId == id);

        //     if (hasMesken.Result.Data != null)
        //     {
        //         return BadRequest(new Result<bool>
        //         {
        //             State = ResultState.Fail,
        //             Message = "Kayıtlı mesken kaydı bulunmaktadır. Silme işlemi yapılamaz."
        //         });
        //     }

        //     var existing = await _blokService.GetByIdAsync(id);
        //     if (existing == null)
        //         return NotFound();

        //     Result<bool> result = await _blokService.Delete(id);
        //     return Ok(result);
        // }

        [HttpPost("GetAllBlokByFilter")]
        public async Task<IActionResult> GetAllBlokByFilter(DataFilterModelView model)
        {
            var result = await _blokService.GetAllAsync(model);
            if (result.Data == null || !result.Data.Any())
                return NotFound("No records found matching the filter criteria.");
            return Ok(result);
        }

        [HttpGet("KatlariHesapla/{blokId}")]
        public IActionResult KatlariHesapla(int blokId)
        {
            return Ok(_blokService.KatlariHesapla(blokId));
        }

        [HttpPost("CreateNewBlokWithMesken")]
        public async Task<IActionResult> CreateNewBlokWithMesken([FromBody] CreateNewBlokWithMeskenRequestDto dto)
        {
            var result = await _blokService.CreateBlokWithMesken(dto);
            if (result.Data == null)
                return NotFound("Data is null");
            return Ok(result);
        }
    }
}