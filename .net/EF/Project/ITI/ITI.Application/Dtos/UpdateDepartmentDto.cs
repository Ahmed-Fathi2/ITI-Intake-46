using System;
using System.Collections.Generic;
using System.Text;

namespace ITI.Application.Dtos
{
    public record UpdateDepartmentDto(int Id, string Name, string? Location, int? ManagerId);
}
