using ITI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITI.Infrastructure.Persistence.Configurations
{
    public class CourseSessionAttendanceConfig : IEntityTypeConfiguration<CourseSessionAttendance>
    {
        public void Configure(EntityTypeBuilder<CourseSessionAttendance> builder)
        {
            builder.HasKey(x => x.Id);


            builder.HasOne(x => x.CourseSession)
                .WithMany(i => i.CourseSessionAttendances)
                .HasForeignKey(x => x.CourseSessionId);

            builder.HasOne(x => x.Student)
           .WithMany(i => i.CourseSessionAttendances)
           .HasForeignKey(x => x.StudentId);
        }
    }
}



