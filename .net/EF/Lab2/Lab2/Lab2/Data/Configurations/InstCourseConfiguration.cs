using Lab2.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2.Data.Configurations
{
    public class InstCourseConfiguration : IEntityTypeConfiguration<InstCourse>
    {
        public void Configure(EntityTypeBuilder<InstCourse> builder)
        {
            builder.HasKey(x => new {x.InsId,x.CrsId });

            builder.Property(x => x.Evaluation)
           .HasMaxLength(50);



            builder.HasOne(x => x.Instractor)
                .WithMany(x => x.instCourses)
                .HasForeignKey(x => x.InsId);




            builder.HasOne(x => x.Course)
                .WithMany(x => x.instCourses)
                .HasForeignKey(x => x.CrsId);

        }
    }
}


