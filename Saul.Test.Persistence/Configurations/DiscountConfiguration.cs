using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Saul.Test.Domain.Entities;

namespace Saul.Test.Persistence.Configurations
{
    public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.Property(t => t.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.Description)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(t => t.Percent)
                .HasPrecision(9, 2)
                .IsRequired();
        }
    }
}
