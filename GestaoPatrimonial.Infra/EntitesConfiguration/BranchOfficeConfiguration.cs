using GestaoPatrimonial.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoPatrimonial.Data.EntitesConfiguration
{
    public class BranchOfficeConfiguration : IEntityTypeConfiguration<BranchOffice>
    {
        public void Configure(EntityTypeBuilder<BranchOffice> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(80);
            builder.Property(x => x.PhoneNumber).HasMaxLength(15);
            builder.Property(x => x.CellPhoneNumber).HasMaxLength(15);
            builder.Property(x => x.ResponsibleName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.ResponsibleEmail).HasMaxLength(80);
            builder.Property(x => x.ResponsiblePhoneNumber).HasMaxLength(15);
            builder.Property(x => x.ResponsibleCellPhoneNumber).HasMaxLength(15);
            builder.Property(x => x.AddressNumber).HasMaxLength(10);
            builder.Property(x => x.AddressComplement).HasMaxLength(80);
            builder.HasIndex(x => x.Email).IsUnique();

            builder.HasOne(x => x.Address).WithMany(y => y.Offices).HasForeignKey(x => x.AddressId);
        }
    }
}
