using System;
using System.Collections.Generic;
using System.Text;

namespace ITI.Application.Dtos
{
    public record UpdateStudentDto(int Id, string? FirstName, string? LastName, string? Phone);
}