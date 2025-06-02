using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Interface;
using BisiyonPanelAPI.View;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BisiyonPanelAPI.Domain;

namespace BisiyonPanelAPI.Api
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginRequestView model)
        {
            Result<LoginResponseView> result = await _userService.Login(model);
            return Ok(result);
        }

        [HttpGet("TestAllUsers")]
        public async Task<IActionResult> TestAllUsers()
        {
            Result<List<User>> result = await _userService.GetAllAsync();
            return Ok(result);
        }
    }
}