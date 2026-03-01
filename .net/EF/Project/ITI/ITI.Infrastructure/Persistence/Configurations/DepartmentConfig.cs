using ITI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITI.Infrastructure.Persistence.Configurations
{
    public class DepartmentConfig : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(255);

            builder.Property(x => x.Location)
                .HasMaxLength(255);


            builder.HasOne(x => x.Instractor)
                .WithOne(i => i.MangedDepartment)
                .HasForeignKey<Department>(x => x.ManagerId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
