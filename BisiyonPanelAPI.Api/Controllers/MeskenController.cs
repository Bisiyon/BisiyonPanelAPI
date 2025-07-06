using BisiyonPanelAPI.Interface;
using Microsoft.AspNetCore.Mvc;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.View.BussinesObjects;
using Microsoft.EntityFrameworkCore; 

namespace BisiyonPanelAPI.Api
{
    public class MeskenController : BaseController
    {
        private readonly IMeskenService _meskenService;

        public MeskenController(IMeskenService meskenService)
        {
            _meskenService = meskenService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Mesken>>> GetAll()
        {
            var result = await _meskenService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Mesken>> GetById(int id)
        {
            var mesken = await _meskenService.GetById(id);
            if (mesken == null)
                return NotFound();
            return Ok(mesken);
        }

        [HttpPost]
        public async Task<ActionResult<Result<Mesken>>> Create([FromBody] MeskenBo bo)
        {
            var result = await _meskenService.InsertAsync(bo);
            if (result.State == ResultState.Fail)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Result<Mesken>>> Update([FromBody] MeskenBo bo)
        {
            var result = await _meskenService.UpdateAsync(bo);
            if (result.State == ResultState.Fail)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Mesken>> Delete(int id)
        {
            var mesken = await _meskenService.DeleteAsync(id);
            if (mesken == null)
                return NotFound();
            return Ok(mesken);
        }

        [HttpPost("GetAllMeskenByFilter")]
        public async Task<IActionResult> GetAllMeskenByFilter(DataFilterModelView model)
        {
            var result = await _meskenService.GetAllAsync(model);
            if (result.Data == null || !result.Data.Any())
                return NotFound("No records found matching the filter criteria.");
            return Ok(result);
        }
        [HttpPost("GetAllMeskenByDto")]
        public async Task<IActionResult> GetAllMeskenByDto()
        {
            var result = await _meskenService.GetAllAsync<MeskenBo>(x => x.Id > 0, includeFunc: q => q
                .Include(y => y.AidatGrup)
                .Include(y => y.MeskenTipi));

            if (result.Data == null || !result.Data.Any())
                return NotFound("No records found matching the filter criteria.");
            return Ok(result);
        }
        [HttpPost("GetAllMeskenByIdDto")]
        public async Task<IActionResult> GetAllMeskenByIdDto()
        {
            var result = await _meskenService.GetByIdAsync<MeskenBo>(10);

            if (result.Data == null)
                return NotFound("No records found matching the filter criteria.");
            return Ok(result);
        }
        [HttpPost("GetAllMeskenList")]
        public async Task<IActionResult> GetAllMeskenList(DataFilterModelView model)
        {
            var result = await _meskenService.GetAllMeskenList(model);
            if (result.Data == null)
                return NotFound("No records found matching the filter criteria.");
            return Ok(result);
        }
    }
}