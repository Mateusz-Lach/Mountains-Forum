using Microsoft.AspNetCore.Mvc;
using Mountains_Forum.Models;
using Mountains_Forum.Services;

namespace Mountains_Forum.Controllers
{
    [ApiController]
    [Route("mountains/account")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost("register")]
        public ActionResult RegisterUser([FromBody] RegisterUserDto dto)
        {
            _accountService.RegisterUser(dto);

            return Ok();
        }
    }
}
