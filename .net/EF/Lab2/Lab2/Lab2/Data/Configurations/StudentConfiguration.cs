using Lab2.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2.Data.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.StId);

            builder.Property(x => x.FName)
                .HasMaxLength(50);

            builder.Property(x => x.FName)
                .HasMaxLength(10);

            builder.Property(x => x.Address)
                .HasMaxLength(100);


            builder.HasOne(x => x.Department)
                .WithMany(x => x.Students)
                .HasForeignKey(x => x.DepartmentId);

            builder.HasOne(x => x.StudSuper)
              .WithMany(x => x.Students)
              .HasForeignKey(x => x.StSuper);

        }
    }
}


