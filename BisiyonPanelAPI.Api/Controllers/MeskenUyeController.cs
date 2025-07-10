using BisiyonPanelAPI.Interface;
using Microsoft.AspNetCore.Mvc;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Common;
using Mapster;
using BisiyonPanelAPI.View.BussinesObjects;

namespace BisiyonPanelAPI.Api
{
    public class MeskenUyeController : BaseController
    {
        private readonly IMeskenUyeService _meskenUyeService;

        public MeskenUyeController(IMeskenUyeService meskenUyeService)
        {
            _meskenUyeService = meskenUyeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MeskenUye>>> GetAll()
        {
            var result = await _meskenUyeService.GetAll();
            return Ok(result);
        }

            [HttpGet("{id}")]
            public async Task<ActionResult<MeskenUye>> GetById(int id)
            {
                var meskenUye = await _meskenUyeService.GetById(id);
                if (meskenUye == null)
                    return NotFound();
                return Ok(meskenUye);
            }

            [HttpPost]
            public async Task<ActionResult<Result<MeskenUye>>> Create([FromBody] MeskenUyeBo bo)
            {
                var result = await _meskenUyeService.InsertAsync(bo);

                if (result.State == ResultState.Fail)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }

            [HttpPut]
            public async Task<ActionResult<Result<MeskenUye>>> Update([FromBody] MeskenUyeBo bo)
            {
                var result = await _meskenUyeService.UpdateAsync(bo);
                if (result.State == ResultState.Fail)
                {
                    return BadRequest(result);
                }
                return Ok(result);
            }

            [HttpDelete("{id}")]
            public async Task<ActionResult<MeskenUye>> Delete(int id)
            {
                var meskenUye = await _meskenUyeService.DeleteAsync(id);
                if (meskenUye == null)
                    return NotFound();
                return Ok(meskenUye);
            }

            [HttpPost("GetAllMeskenUyeByFilter")]
            public async Task<IActionResult> GetAllMeskenUyeByFilter(DataFilterModelView model)
            {
                var result = await _meskenUyeService.GetAllAsync(model);
                if (result.Data == null || !result.Data.Any())
                    return NotFound("No records found matching the fmeskenUyeter criteria.");
                return Ok(result);
            }
    }
}