using System;
using System.Collections.Generic;
using System.Text;

namespace ITI.Application.Dtos
{
    public record CreateDepartmentDto(string Name, string? Location, int? ManagerId);
}
