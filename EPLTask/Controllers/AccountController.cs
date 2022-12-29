using Auth.DTO;
using Auth.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace EPLTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuth _auth;
        public AccountController(IAuth auth)
        {
            _auth = auth;
        }
        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginDTO loginDTO)
        {
            if (ModelState.IsValid)
            {
                var result = await _auth.Login(loginDTO);
                return StatusCode(result.Code, result);
            }
            return BadRequest();

        }
        [HttpGet("Logout")]
        public async Task<IActionResult> Logout()
        {
            if (ModelState.IsValid)
            {
                var result = await _auth.Logout();
                return StatusCode(result.Code, result);
            }
            return BadRequest();
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterDTO model)
        {
            if (ModelState.IsValid)
            {
                var result = await _auth.Register(model);
                return StatusCode(result.Code, result);
            }
            return BadRequest();
        }
    }
}
