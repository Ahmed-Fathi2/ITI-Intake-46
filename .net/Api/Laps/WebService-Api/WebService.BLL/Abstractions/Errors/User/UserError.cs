using System;
using System.Collections.Generic;
using System.Text;

namespace WebService.BLL.Abstractions.Errors.User
{
    public class UserError
    {
        public static readonly Error EmailAlreadyExists = new ("EmailAlreadyExist", "Email already exist", ErrorStatusCodes.Conflict);
        public static readonly Error InvalidEmailOrPassword = new ("InvalidEmailOrPassword", "Invalid email or password", ErrorStatusCodes.Unauthorized);
        public static readonly Error EmailNotConfirmed = new ("EmailNotConfirmed", "Email not confirmed", ErrorStatusCodes.Unauthorized);
    }
}
