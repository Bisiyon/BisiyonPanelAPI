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