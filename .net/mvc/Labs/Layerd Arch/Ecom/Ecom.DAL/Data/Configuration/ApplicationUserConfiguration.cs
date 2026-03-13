using Ecom.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom.DAL.Data.Configuration
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(x=>x.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x=>x.LastName)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
