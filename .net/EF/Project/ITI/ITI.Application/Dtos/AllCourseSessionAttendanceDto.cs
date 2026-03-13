namespace ITI.Application.Dtos
{
    public record AllCourseSessionAttendanceDto(int Id, int? Grade, string? Notes, int StudentId, int CourseSessionId, string? StudentName, string? CourseSessionTitle);
}
