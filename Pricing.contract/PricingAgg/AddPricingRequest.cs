namespace Pricing_contract.PricingAgg;

public class AddPricingRequest
{
    public int ThingId { get; set; }
    public DateOnly Date { get; set; }
    public int PriceGrade1 { get; set; }
    public int PriceGrade2 { get; set; }
}

public class StopPricingRequest
{
    public int ThingId { get; set; }
    public DateOnly DateEnd { get; set; }
}
