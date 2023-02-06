using Microsoft.AspNetCore.Mvc;
using Vim.Dtos;
using Vim.Services;
using Vim.Wrappers;

namespace Vim.Controllers
{

    public class AccountController : BaseApiController
    {
        private readonly AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }


        [HttpPost("login")]
        public async Task<ActionResult> Login (LoginDto login)
        {
            LoginResponsDto response = null;
            if (ModelState.IsValid)
                response = await _accountService.LoginAsync(login);
            return response.IsSucceeded ? Ok(new ApiResponse<LoginResponsDto>(response, 200, "Succeede")) : Unauthorized(new ErrorResponse(401));
        }



        public async Task<ActionResult> LogOut()
        {
            await _accountService.Logout();
            return Ok(new ApiResponse(200, "Succeeded"));
        }
    }
}
