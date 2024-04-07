using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerApplication.Domain;

namespace ServerApplication.Configs
{
    public class SparePartsConfig: IEntityTypeConfiguration<SpareParts>
    {
        public void Configure(EntityTypeBuilder<SpareParts> builder)
        {
            // Primary Key
            builder.HasKey(sp => sp.Id);

            // Properties
            builder.Property(sp => sp.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(sp => sp.Description)
                .HasMaxLength(1000);

            builder.Property(sp => sp.Brand)
                .HasMaxLength(100);

            builder.Property(sp => sp.Quantity)
                .IsRequired();

            builder.Property(sp => sp.MadeIn)
                .HasMaxLength(100);

            builder.Property(sp => sp.IsSuspended)
                .IsRequired();

            builder.Property(sp => sp.CreatedOn)
                .IsRequired();

            builder.Property(sp => sp.UpdatedOn)
                .IsRequired();
            builder.Property(sp => sp.Model).IsRequired();
        }
    }
}