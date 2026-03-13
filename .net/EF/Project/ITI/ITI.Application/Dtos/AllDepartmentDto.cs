using System;
using System.Collections.Generic;
using System.Text;

namespace ITI.Application.Dtos
{
    public record AllDepartmentDto(int Id, string Name, string? Location, int? ManagerId);
}
