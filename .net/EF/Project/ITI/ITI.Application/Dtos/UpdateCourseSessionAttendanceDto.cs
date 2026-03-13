namespace ITI.Application.Dtos
{
    public record UpdateCourseSessionAttendanceDto(int Id, int? Grade, string? Notes, int StudentId, int CourseSessionId);
}
