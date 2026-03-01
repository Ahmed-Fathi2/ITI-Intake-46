using ITI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITI.Infrastructure.Persistence.Configurations
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName)
                .HasMaxLength(255);

            builder.Property(x => x.LastName)
                .HasMaxLength(255);

            builder.Property(x => x.Phone)
                .HasMaxLength(255);
        }
    }
}


