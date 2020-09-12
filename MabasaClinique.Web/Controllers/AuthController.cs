using System.Threading.Tasks;
using HealthClinique.Data.Models;
using HealthClinique.Service.User;
using Microsoft.AspNetCore.Mvc;

namespace MabasaClinique.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterPatient([FromBody] RegisterUser user)
        {
            if (ModelState.IsValid)
                return Ok(await _userService.RegisterPatient(user));
            return BadRequest();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginPatient([FromBody] LoginUser user)
        {
            if (ModelState.IsValid)
                return Ok(await _userService.LoginPatient(user));
            return BadRequest();
        }
    }
}