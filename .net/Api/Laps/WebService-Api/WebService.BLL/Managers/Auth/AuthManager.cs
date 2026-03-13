using Mapster;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using WebService.BLL.Abstractions;
using WebService.BLL.Abstractions.Constants;
using WebService.BLL.Abstractions.Errors.User;
using WebService.BLL.Dtos.Auth;
using WebService.DAL.Data.Entities;


namespace WebService.BLL.Managers.Auth
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthManager(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
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
            var user = await _userManager.FindByEmailAsync(loginRequestDto.Email);
            if (user is null)
                return Result.Failure<LoginResponse>(UserError.InvalidEmailOrPassword);

            //if (!user.EmailConfirmed)
            //    return Result.Failure<LoginResponse>(UserError.EmailNotConfirmed);

          var result=await _signInManager.PasswordSignInAsync(user, loginRequestDto.Password, false, false);
            if (!result.Succeeded)
                return Result.Failure<LoginResponse>(UserError.InvalidEmailOrPassword);


            //ToDo
            // Generate JWT Token


            var response = new LoginResponse (Id : user.Id, FirstName : user.FirstName,LastName:user.LastName, Email : user.Email! ,Token:"ds" , ExpiresIn:3600);
            return Result.Success(response);


        }

        public async Task<Result> RegisterAsync(RegisterRequestDto registerRequestDto)
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

            return Result.Success();


        }
    }
}
