using ITI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITI.Infrastructure.Persistence.Configurations
{
    public class InstractorConfig : IEntityTypeConfiguration<Instractor>
    {
        public void Configure(EntityTypeBuilder<Instractor> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName)
                .HasMaxLength(255);

            builder.Property(x => x.LastName)
                .HasMaxLength(255);

            builder.Property(x => x.Phone)
                .HasMaxLength(255);


            builder.HasOne(x => x.Department)
                .WithMany(i => i.Instractors)
                .HasForeignKey(x => x.DepartmentId);


        }
    }
}


