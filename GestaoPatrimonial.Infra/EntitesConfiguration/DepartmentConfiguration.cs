using GestaoPatrimonial.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoPatrimonial.Data.EntitesConfiguration
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Initials).HasMaxLength(10);
            builder.HasIndex(x => x.Initials).IsUnique();

            builder.HasOne(x => x.BranchOffice).WithMany(y => y.Departments).HasForeignKey(x => x.BranchOfficeId);
        }
    }
}
