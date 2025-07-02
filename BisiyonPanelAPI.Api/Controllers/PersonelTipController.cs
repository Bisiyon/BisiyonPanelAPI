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