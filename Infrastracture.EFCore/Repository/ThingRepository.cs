using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using Pricing_contract.ThingAgg;
using Pricing_Entity;

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