using GestaoPatrimonial.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoPatrimonial.Data.EntitesConfiguration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.PostalCode).HasMaxLength(10).IsRequired();
            builder.Property(x => x.PublicPlace).HasMaxLength(100);
            builder.Property(x => x.District).HasMaxLength(50);
            builder.Property(x => x.City).HasMaxLength(50);
            builder.Property(x => x.State).HasMaxLength(2);
        }
    }
}
