namespace ITI.Application.Dtos
{
    public record UpdateCourseSessionDto(int Id, DateOnly Date, string? Title, int CourseId, int InstractorId);
}
