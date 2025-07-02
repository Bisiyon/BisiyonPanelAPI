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