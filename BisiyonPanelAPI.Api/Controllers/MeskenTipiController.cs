using BisiyonPanelAPI.Interface;
using Microsoft.AspNetCore.Mvc;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.View.BussinesObjects;

namespace BisiyonPanelAPI.Api
{
    public class MeskenTipiController : BaseController
    {
        private readonly IMeskenTipiService _meskenTipiService;

        public MeskenTipiController(IMeskenTipiService meskenTipiService)
        {
            _meskenTipiService = meskenTipiService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MeskenTipi>>> GetAll()
        {
            var result = await _meskenTipiService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MeskenTipi>> GetById(int id)
        {
            var meskenTipi = await _meskenTipiService.GetById(id);
            if (meskenTipi == null)
                return NotFound();
            return Ok(meskenTipi);
        }

        [HttpPost]
        public async Task<ActionResult<Result<MeskenTipi>>> Create([FromBody] MeskenTipiBo bo)
        {
            var result = await _meskenTipiService.InsertAsync(bo);
            if (result.State == ResultState.Fail)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Result<MeskenTipi>>> Update([FromBody] MeskenTipiBo bo)
        {
            var result = await _meskenTipiService.UpdateAsync(bo);
            if (result.State == ResultState.Fail)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MeskenTipi>> Delete(int id)
        {
            var meskenTipi = await _meskenTipiService.DeleteAsync(id);
            if (meskenTipi == null)
                return NotFound();
            return Ok(meskenTipi);
        }

        [HttpPost("GetAllMeskenTipiByFilter")]
        public async Task<IActionResult> GetAllMeskenTipiByFilter(DataFilterModelView model)
        {
            var result = await _meskenTipiService.GetAllAsync(model);
            if (result.Data == null || !result.Data.Any())
                return NotFound("No records found matching the filter criteria.");
            return Ok(result);
        }
    }
}