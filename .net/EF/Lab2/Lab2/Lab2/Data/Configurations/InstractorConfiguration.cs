using Lab2.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab2.Data.Configurations
{
    public class InstractorConfiguration : IEntityTypeConfiguration<Instractor>
    {
        public void Configure(EntityTypeBuilder<Instractor> builder)
        {
            builder.HasKey(x => x.InsId);

            builder.Property(x => x.InsName)
           .HasMaxLength(50);

            builder.Property(x => x.InsDegree)
                .HasMaxLength(50);

            builder.HasOne(x => x.Department)
                .WithMany(x => x.Instractors)
                .HasForeignKey(x => x.DeptId);

        }
    }
}

