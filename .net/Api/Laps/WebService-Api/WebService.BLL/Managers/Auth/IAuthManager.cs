using WebService.BLL.Abstractions;
using WebService.BLL.Dtos.Auth;

namespace WebService.BLL.Managers.Auth
{
    public interface IAuthManager
    {
        Task<Result> RegisterAsync(RegisterRequestDto registerRequestDto,string origin);

        Task<Result<LoginResponse>> LoginAsync(LoginRequestDto loginRequestDto);

        Task<Result> AddRole(string RoleName);

        Task<Result> ConfirmEmail(EmailConfirmationRequestDto emailConfirmationRequestDto);
    }
}
