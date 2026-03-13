namespace ITI.Application.Dtos
{
    public record CreateCourseSessionAttendanceDto(int? Grade, string? Notes, int StudentId, int CourseSessionId);
}
