using ITI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITI.Infrastructure.Persistence.Configurations
{
    public class StudentCourseConfig : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            builder.HasKey(x => new {x.StudentId,x.CourseId });


            builder.HasOne(x => x.Student)
                .WithMany(i => i.StudentCourses)
                .HasForeignKey(x => x.StudentId);

            builder.HasOne(x => x.Course)
               .WithMany(i => i.StudentCourses)
               .HasForeignKey(x => x.CourseId);
        }
    }
}
