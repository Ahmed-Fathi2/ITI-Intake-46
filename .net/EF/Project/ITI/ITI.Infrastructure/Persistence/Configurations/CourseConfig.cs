using ITI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITI.Infrastructure.Persistence.Configurations
{
    public class CourseConfig : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(255);



            builder.HasOne(x => x.Instractor)
                .WithMany(i => i.Courses)
                .HasForeignKey(x => x.InstractorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Department)
                .WithMany(i => i.Courses)
                .HasForeignKey(x => x.DepartmentId);
        }
    }
}




