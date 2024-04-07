using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerApplication.Domain;

namespace ServerApplication.Configs;

public class CustomerAddressConfig : IEntityTypeConfiguration<CustomerAddress>
{
    public void Configure(EntityTypeBuilder<CustomerAddress> builder)
    {
        builder.HasKey(p => p.Id);
        builder.HasOne(p => p.User).WithMany(p => p.CustomerAddresses).HasForeignKey(p => p.UserId);
    }
}