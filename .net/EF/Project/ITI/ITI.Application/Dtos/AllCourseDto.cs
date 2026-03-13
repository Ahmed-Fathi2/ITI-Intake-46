namespace ITI.Application.Dtos
{
    public record AllCourseDto(int Id, string? Name, int? Duration, int InstractorId, int DepartmentId, string? InstractorName, string? DepartmentName);
}
