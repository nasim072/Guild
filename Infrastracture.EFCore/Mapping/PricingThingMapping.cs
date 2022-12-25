using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pricing_Entity;

namespace Infrastracture.EFCore.Mapping
{
    public class PricingThingMapping : IEntityTypeConfiguration<PricingThing>
    {
        public void Configure(EntityTypeBuilder<PricingThing> builder)
        {
            builder.ToTable("PricingThings");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DateStart).IsRequired();
            builder.Property(x => x.ThingId).IsRequired();


        }
    }
}
