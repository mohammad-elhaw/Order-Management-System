using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OrderSystem.Infrastructure.Config;
internal class CustomerConfig : IEntityTypeConfiguration<Domain.Entities.Customer>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Customer> builder)
    {
        builder.HasOne(c => c.User)
            .WithOne()
            .HasForeignKey<Domain.Entities.Customer>(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
