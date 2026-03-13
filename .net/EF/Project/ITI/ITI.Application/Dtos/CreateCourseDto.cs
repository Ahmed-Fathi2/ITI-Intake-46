namespace ITI.Application.Dtos
{
    public record CreateCourseDto(string? Name, int? Duration, int InstractorId, int DepartmentId);
}
