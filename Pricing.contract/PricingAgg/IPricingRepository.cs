using System.Linq.Expressions;
using Pricing_Entity;

namespace Pricing_contract.PricingAgg;

public interface IPricingRepository
{
    PricingThing? GetLastPricingThing(Expression<Func<PricingThing, bool>> expression);
    void Add(PricingThing request);
    void Update(PricingThing request) => throw new NotImplementedException();
    long Exit(Expression<Func<PricingThing, bool>> expression)=>throw new NotImplementedException();
    void SaveChange();
    IQueryable<PricingThing> GetPricingThings(Expression<Func<PricingThing, bool>> expression);
}