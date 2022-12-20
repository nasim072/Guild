using _0_Framework.Application;
using Pricing_Entity;

namespace Pricing_contract.PricingAgg;

public interface IPricingApplication
{
    public OperationResult PricingByDate(AddPricingRequest request);
    public OperationResult RemovePricingInDate(StopPricingRequest request);
 
    OperationResult Restore(int Id);
    OperationResult RestoreAll();
    public IList<PricingThing> GetFinalListPricing(DateOnly? date);
}