namespace ITI.Application.Dtos
{
    public record UpdateCourseDto(int Id, string? Name, int? Duration, int InstractorId, int DepartmentId);
}
