using FluentValidation;
using WebService.BLL.Dtos.Auth;

namespace WebService.BLL.Validation.Auth
{
    public class LoginRequestDtoValidator:AbstractValidator<LoginRequestDto>
    {

        public LoginRequestDtoValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty();

            RuleFor(x => x.Password)
                .NotEmpty();
        }
    }
}
