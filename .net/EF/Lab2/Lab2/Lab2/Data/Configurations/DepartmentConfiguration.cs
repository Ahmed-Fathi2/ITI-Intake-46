using Lab2.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2.Data.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(x => x.DeptId);

            builder.Property(x => x.DeptName)
              .HasMaxLength(50);

            builder.Property(x => x.DeptDesc)
                .HasMaxLength(100);

            builder.Property(x => x.DeptLocation)
                .HasMaxLength(50);

            builder.HasOne(x => x.Instractor)
                .WithMany(x => x.Departments)
                .HasForeignKey(x => x.DeptManager);
        }
    }
}






   