namespace ITI.Application.Dtos
{
    public record AllCourseSessionDto(int Id, string? Title, DateOnly Date, int CourseId, int InstractorId, string? CourseName, string? InstractorName);
}
