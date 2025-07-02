using BisiyonPanelAPI.Interface;
using Microsoft.AspNetCore.Mvc;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.View;
using Microsoft.AspNetCore.Authorization;
using BisiyonPanelAPI.View.BussinesObjects;

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
            var result = await _blokService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Blok>> GetById(int id)
        {
            var blok = await _blokService.GetById(id);
            if (blok == null)
                return NotFound();
            return Ok(blok);
        }

        [HttpPost]
        public async Task<ActionResult<Result<Blok>>> Create([FromBody] BlokBo bo)
        {
            var result = await _blokService.InsertAsync(bo);
            if (result.State == ResultState.Fail)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Result<Blok>>> Update([FromBody] BlokBo bo)
        {
            var result = await _blokService.UpdateAsync(bo);
            if (result.State == ResultState.Fail)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Blok>> Delete(int id)
        {
            var blok = await _blokService.DeleteAsync(id);
            if (blok == null)
                return NotFound();
            return Ok(blok);
        }

        [HttpPost("GetAllBlokByFilter")]
        public async Task<IActionResult> GetAllBlokByFilter(DataFilterModelView model)
        {
            var result = await _blokService.GetAllAsync(model);
            if (result.Data == null || !result.Data.Any())
                return NotFound("No records found matching the filter criteria.");
            return Ok(result);
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