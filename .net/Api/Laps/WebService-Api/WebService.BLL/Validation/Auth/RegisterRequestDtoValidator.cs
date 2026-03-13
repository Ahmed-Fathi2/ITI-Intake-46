using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using WebService.BLL.Dtos.Auth;

namespace WebService.BLL.Validation.Auth
{
    public class RegisterRequestDtoValidator : AbstractValidator<RegisterRequestDto>
    {
        public RegisterRequestDtoValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .Length(3, 256);

            RuleFor(x => x.LastName)
              .NotEmpty()
              .Length(3, 256);

            RuleFor(x => x.Email)
              .NotEmpty()
              .EmailAddress();

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required.")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$")
                .WithMessage("Password must be at least 8 characters long and contain at least one uppercase letter (A-Z), one lowercase letter (a-z), one number (0-9), and one special character (e.g. !@#$%^&*).");
        }
    }
}

