namespace ITI.Application.Dtos
{
    public record AllInstractorDto(int Id, string? FirstName, string? LastName, string? Phone, int DepartmentId)
    {
        public string FullName => $"{FirstName} {LastName}".Trim();
    }
}
