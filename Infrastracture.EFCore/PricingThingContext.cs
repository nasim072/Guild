using Infrastracture.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;
using Pricing_Entity;

namespace Infrastracture.EFCore;

public class PricingThingContext:DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Thing> Things { get; set; }
    public DbSet<PricingThing> Pricing { get; set; }

    public PricingThingContext(DbContextOptions<PricingThingContext> options):base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var assembly = typeof(PricingThingMapping).Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        base.OnModelCreating(modelBuilder);
    }
}