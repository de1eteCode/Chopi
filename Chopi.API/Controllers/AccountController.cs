using Chopi.Modules.EFCore.Repositories.Interfaces.IUnitOfWorks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Chopi.API.Controllers
{
    /// <summary>
    /// Функции для работы пользователя со своим аккаунтом
    /// </summary>
    
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IUnitOfAccounts _unit;

        public AccountController(IUnitOfAccounts unit)
        {
            _unit = unit;
        }

        [HttpPost("auth")]
        [AllowAnonymous]
        public IActionResult Login()
        {
            throw new NotImplementedException();
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public IActionResult Register()
        {
            throw new NotImplementedException();
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            throw new NotImplementedException();
        }

        [HttpGet("getinfo")]
        public IActionResult GetInfo()
        {
            throw new NotImplementedException();
        }
    }
}
