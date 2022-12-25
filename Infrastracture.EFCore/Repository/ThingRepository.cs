using Pricing_Entity;
using System.Linq.Expressions;

namespace Infrastracture.EFCore.Repository;

public class ThingRepository : IThingRepository
{
    readonly PricingThingContext _pricingContext;

    public ThingRepository(PricingThingContext pricingContext)
    {
        _pricingContext = pricingContext;
    }

    public void Add(Thing thing)
    {
        _pricingContext.Things.Add(thing);
    }

    public void Update(Thing thing)
    {
        _pricingContext.Things.Update(thing);
    }

    public bool Exit(Expression<Func<Thing, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public void SaveChange()
    {
        throw new NotImplementedException();
    }
    public void AddNewCategory(Category category)
    {
        _pricingContext.Categories.Add(category);
    }
}