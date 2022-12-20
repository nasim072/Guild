namespace Pricing_contract.PricingAgg;

public class EditPricingRequest : AddPricingRequest
{
    public long Id { get; set; }
}

public class PricingThingInDate
{
    public long Id { get; set; }
    public int PriceGrade1 { get; set; }
    public int PriceGrade2 { get; set; }

}