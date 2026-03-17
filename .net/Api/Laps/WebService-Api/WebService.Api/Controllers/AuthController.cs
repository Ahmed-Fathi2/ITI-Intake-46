using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebService.BLL.Abstractions;
using WebService.BLL.Dtos.Auth;
using WebService.BLL.Managers.Auth;

namespace WebService.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthManager _authManger;

        public AuthController(IAuthManager authManger)
        {
            _authManger = authManger;
        }
        [HttpPost("register")]

        public async Task<ActionResult<Result>> Register(RegisterRequestDto registerRequestDto)
        {
            var origin = Request.Headers.Origin.ToString(); // Scheme + Host + Port (e.g., http://localhost:3000)
            var result = await _authManger.RegisterAsync(registerRequestDto,origin);  
            
            return result.IsSuccess ? Ok() : result.ToProblem();
        }

        [HttpPost]

        public async Task<ActionResult<Result>> Login(LoginRequestDto loginRequestDto)
        {

            var result = await _authManger.LoginAsync(loginRequestDto);

            return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
        }


        [HttpGet("emailConfirmation")]
        public async Task<ActionResult<Result>> EmailConfirmation([FromQuery]EmailConfirmationRequestDto emailConfirmationRequestDto)
        {

            var result = await _authManger.ConfirmEmail(emailConfirmationRequestDto);

            return result.IsSuccess ? Ok() : result.ToProblem();
          
        }
    }
}
