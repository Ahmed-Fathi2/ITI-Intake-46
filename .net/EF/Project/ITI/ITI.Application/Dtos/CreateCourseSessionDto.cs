namespace ITI.Application.Dtos
{
    public record CreateCourseSessionDto(DateOnly Date, string? Title, int CourseId, int InstractorId);
}
