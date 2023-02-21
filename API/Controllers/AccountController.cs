using Application.Common.Interfaces;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        private readonly ICurrentUserService _currentUserService;

        public AccountController(IIdentityService identityService, ICurrentUserService currentUserService)
        {
            _identityService = identityService;
            _currentUserService = currentUserService;
        }

        [HttpPost("Login")]
        public async Task<JsonResult> Login(string userName, string password)
        {
            return await _identityService.Login(userName, password);
        }

        [HttpPost("Register")]
        public async Task<string> Register(string userName, string password)
        {
            return await _identityService.CreateUserAsync(userName, password);
        }

        [HttpPost("RefreshToken")]
        public JsonResult RefreshToken()
        {
            string? email = _currentUserService.Email;
            return _identityService.RefreshToken(email);
        }
    }
}
