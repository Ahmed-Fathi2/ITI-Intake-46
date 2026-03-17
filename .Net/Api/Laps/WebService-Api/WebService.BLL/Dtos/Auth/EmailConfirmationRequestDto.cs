using System;
using System.Collections.Generic;
using System.Text;

namespace WebService.BLL.Dtos.Auth
{
    public sealed record EmailConfirmationRequestDto
     (
        string userId,
        string code
     );
}
