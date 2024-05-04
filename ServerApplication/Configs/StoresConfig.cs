using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServerApplication.Domain;

namespace ServerApplication.Configs
{
    public class StoresConfig: IEntityTypeConfiguration<Stores>
    {
        public void Configure(EntityTypeBuilder<Stores> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(s => s.OwnerId).IsRequired();

            builder.Property(s => s.rate)
                .IsRequired();                

            builder.Property(s => s.CreatedOn)
                .IsRequired();

            builder.Property(s => s.UpdatedOn)
                .IsRequired();
            builder.HasOne(s => s.CustomerAddresses)
                .WithOne(ca => ca.Store)
                .HasForeignKey<CustomerAddress>(ca => ca.StoreId);
        }
    }
}