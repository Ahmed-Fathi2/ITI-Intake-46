using System;
using System.Collections.Generic;
using System.Text;

namespace WebService.BLL.Dtos.Auth
{
    public sealed  record RegisterRequestDto( string FirstName,string LastName,string Email, string Password);
    
}
