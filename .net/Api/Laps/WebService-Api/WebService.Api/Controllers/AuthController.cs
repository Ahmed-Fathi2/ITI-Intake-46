using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebService.BLL.Abstractions;
using WebService.BLL.Dtos.Auth;
using WebService.BLL.Managers.Auth;

namespace WebService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthManager _authManger;

        public AuthController(IAuthManager authManger)
        {
            _authManger = authManger;
        }
        [HttpPost]

        public async Task<ActionResult<Result>> Register(RegisterRequestDto registerRequestDto)
        {

            var result = await _authManger.RegisterAsync(registerRequestDto);  
            
            return result.IsSuccess ? Ok() : result.ToProblem();
        }
    }
}
