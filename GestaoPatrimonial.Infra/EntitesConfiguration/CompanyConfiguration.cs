using GestaoPatrimonial.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoPatrimonial.Data.EntitesConfiguration
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.CorporateName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.CnpjCpf).HasMaxLength(20).IsRequired();
            builder.Property(x => x.IeRg).HasMaxLength(20);
            builder.Property(x => x.ResponsibleName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.PhoneNumber).HasMaxLength(15);
            builder.Property(x => x.CellPhoneNumber).HasMaxLength(15);
            builder.Property(x => x.Email).HasMaxLength(80).IsRequired();
            builder.Property(x => x.AddressNumber).HasMaxLength(10);
            builder.Property(x => x.AddressComplement).HasMaxLength(80);
            builder.HasIndex(x => x.CnpjCpf).IsUnique();

            builder.HasOne(x => x.Address).WithMany(y => y.Companies).HasForeignKey(x => x.AddressId);
        }
    }
}
