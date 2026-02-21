using Lab2.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2.Data.Configurations
{
    public class StudCourseConfiguration : IEntityTypeConfiguration<StudCourse>
    {
        public void Configure(EntityTypeBuilder<StudCourse> builder)
        {
            builder.HasKey(x => new { x.StId, x.CrsId });


            builder.HasOne(x => x.Student)
                .WithMany(x => x.StudCourses)
                .HasForeignKey(x => x.StId);


            builder.HasOne(x => x.Course)
                .WithMany(x => x.StudCourses)
                .HasForeignKey(x => x.CrsId);
        }
    }
}
