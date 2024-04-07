using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerApplication.Domain;

namespace ServerApplication.Configs;

public class OrdersConfig : IEntityTypeConfiguration<Orders>
{
    public void Configure(EntityTypeBuilder<Orders> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.CustomerId)
            .IsRequired();
        builder.Property(p => p.PartId)
            .IsRequired();
        builder.Property(p => p.StoreId)
            .IsRequired();
        builder.Property(p => p.Quantities)
            .IsRequired();
        builder.Property(p => p.TotalPrice)
            .IsRequired();
        builder.Property(p => p.OrderDate)
            .IsRequired();
        builder.Property(p => p.OrderStatus)
            .IsRequired()
            .HasConversion<string>();
        builder.Property(p => p.CreatedOn)
            .IsRequired();
        builder.Property(p => p.UpdatedOn)
            .IsRequired();
    }
}