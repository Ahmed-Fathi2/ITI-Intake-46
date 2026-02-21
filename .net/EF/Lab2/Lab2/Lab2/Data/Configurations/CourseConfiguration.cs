using Lab2.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab2.Data.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {

            builder.HasKey(x => x.CrsId);

            builder.Property(x => x.CrsName)
              .HasMaxLength(50);


            builder.HasOne(x => x.Topic)
                .WithMany(x => x.Courses)
                .HasForeignKey(x => x.TopId);

        }
    }
}



