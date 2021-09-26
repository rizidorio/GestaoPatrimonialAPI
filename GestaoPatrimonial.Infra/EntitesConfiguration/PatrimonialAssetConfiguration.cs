using GestaoPatrimonial.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoPatrimonial.Data.EntitesConfiguration
{
    public class PatrimonialAssetConfiguration : IEntityTypeConfiguration<PatrimonialAsset>
    {
        public void Configure(EntityTypeBuilder<PatrimonialAsset> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.PurchasePrice).HasColumnType("decimal(10,2)");
            builder.Property(x => x.PurchaseQuantity).HasColumnType("decimal(8,2)");
            builder.Property(x => x.Supplier).HasMaxLength(80);
            builder.Property(x => x.Invoice).HasMaxLength(10);
            builder.Property(x => x.PurchaseTotalValue).HasColumnType("decimal(15,2)");

            builder.HasOne(x => x.Subcategory).WithMany(y => y.PatrimonialAssets).HasForeignKey(x => x.SubcategoryId);
            builder.HasOne(x => x.Department).WithMany(y => y.PatrimonialAssets).HasForeignKey(x => x.DepartmentId);
        }
    }
}
