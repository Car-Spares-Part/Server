using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerApplication.Domain;

namespace ServerApplication.Configs
{
    public class PricingConfig: IEntityTypeConfiguration<Pricing>
    {
        public void Configure(EntityTypeBuilder<Pricing> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Price).IsRequired();

            builder.Property(p => p.StoreId).IsRequired();

            builder.Property(p => p.SparePartId).IsRequired();

            builder.Property(p => p.CreatedOn).IsRequired();

            builder.Property(p => p.UpdatedOn).IsRequired();
        }
    }
}