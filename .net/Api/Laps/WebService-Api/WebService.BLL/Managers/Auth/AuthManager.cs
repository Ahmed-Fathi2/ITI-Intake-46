using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using WebService.BLL.Abstractions;
using WebService.BLL.Abstractions.Auth;
using WebService.BLL.Abstractions.Constants;
using WebService.BLL.Abstractions.Errors.User;
using WebService.BLL.Dtos.Auth;
using WebService.BLL.Managers.Email;
using WebService.DAL.Data.Entities;


namespace WebService.BLL.Managers.Auth
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IJwtProvider _jwtProvider;
        private readonly IEmailSender _emailSender;

        public AuthManager(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signInManager,
            IJwtProvider jwtProvider,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _jwtProvider = jwtProvider;
            _emailSender = emailSender;
        }

        public async Task<Result> AddRole(string RoleName)
        {
            var result = await _roleManager.CreateAsync(new IdentityRole(RoleName));
            if (!result.Succeeded)
            {
                var error = result.Errors.First();
                return Result.Failure(new Error(error.Code, error.Description, ErrorStatusCodes.BadRequest));
            }

            return Result.Success();
        }


        public async Task<Result<LoginResponse>> LoginAsync(LoginRequestDto loginRequestDto)
        {


            // 1-  Validate Email
            var user = await _userManager.FindByEmailAsync(loginRequestDto.Email);
            if (user is null)
                return Result.Failure<LoginResponse>(UserError.InvalidEmailOrPassword);


            // 2- Validate     1- Email Confirmation  2- Lockout   3- Password InOrder
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginRequestDto.Password, lockoutOnFailure: true);
            if (!result.Succeeded)
            {
                var error = result.IsNotAllowed
                    ? UserError.EmailNotConfirmed
                    : result.IsLockedOut
                    ? UserError.UserLockedOut
                    : UserError.InvalidEmailOrPassword;

                return Result.Failure<LoginResponse>(error);
            }

            var roles = await _userManager.GetRolesAsync(user);


            // Generate JWT Token
            var (token, expireIn) = _jwtProvider.GenerateToken(user, roles);
            var response = new LoginResponse(
                                Id: user.Id, FirstName: user.FirstName,
                                LastName: user.LastName, Email: user.Email!,
                                Token: token, ExpiresIn: expireIn);

            return Result.Success(response);


        }

        public async Task<Result> RegisterAsync(RegisterRequestDto registerRequestDto, string origin)
        {
            var userIsExist = await _userManager.FindByEmailAsync(registerRequestDto.Email);
            if (userIsExist is not null)
                return Result.Failure(UserError.EmailAlreadyExists);

            var user = registerRequestDto.Adapt<ApplicationUser>();


            var userResult = await _userManager.CreateAsync(user, registerRequestDto.Password);

            if (!userResult.Succeeded)
            {
                var error = userResult.Errors.First();
                return Result.Failure(new Error(error.Code, error.Description, ErrorStatusCodes.BadRequest));

            }


            var roleResult = await _userManager.AddToRoleAsync(user, DefaultRole.User);

            if (!roleResult.Succeeded)
            {
                var error = roleResult.Errors.First();
                return Result.Failure(new Error(error.Code, error.Description, ErrorStatusCodes.BadRequest));
            }


            //ToDo
            // Send Confirmation Email

            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));




            var result = await _emailSender.SendEmailAsync(
              email: user.Email!,
              subject: "Confirm your email",
              htmlMessage: $"<h1>Welcome {user.FirstName} {user.LastName} </h1><p>Please confirm your email by clicking the link below:</p><a href='{origin}/Auth/emailConfirmation?userId={user.Id}&code={code}'>Confirm Email</a>"
            );

            if (!result.IsSuccess)
            {
                var error = result.Errors.First();
                return Result.Failure(new Error(error.Code, error.Description, ErrorStatusCodes.BadRequest));
            }

            return Result.Success();


        }


        public async Task<Result> ConfirmEmail(EmailConfirmationRequestDto emailConfirmationRequestDto)
        {
            var user = await _userManager.FindByIdAsync(emailConfirmationRequestDto.userId);

            if (user is null)
                return Result.Failure(UserError.UserNotFound);

            var code = emailConfirmationRequestDto.code;

            try
            {
                code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            }
            catch (FormatException)
            {
                return Result.Failure(UserError.InvalidCode);
            }

            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (!result.Succeeded)
            {
                var error = result.Errors.First();
                return Result.Failure(new Error(error.Code, error.Description, ErrorStatusCodes.BadRequest));
            }
            return Result.Success();
        }
    }
}
