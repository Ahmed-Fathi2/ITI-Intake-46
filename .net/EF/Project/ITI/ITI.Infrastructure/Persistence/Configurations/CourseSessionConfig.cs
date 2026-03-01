using ITI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITI.Infrastructure.Persistence.Configurations
{
    public class CourseSessionConfig : IEntityTypeConfiguration<CourseSession>
    {
        public void Configure(EntityTypeBuilder<CourseSession> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .HasMaxLength(255);


            builder.HasOne(x => x.Course)
                .WithMany(i => i.CourseSessions)
                .HasForeignKey(x => x.CourseId);


            builder.HasOne(x=>x.Instractor)
                .WithMany(x=>x.CourseSessions)
                .HasForeignKey(x=>x.InstractorId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}



