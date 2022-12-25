using _0_Framework.Common;

namespace Pricing_Entity;

public class PricingThing
{
    public PricingThing(int thingId, DateOnly date)
    {
        ThingId = thingId;
        DateStart = date.ToString();

        IsDeleted = true;
    }

    public PricingThing()
    {

    }

    public long Id { get; set; }
    public int ThingId { get; set; }
    public Thing? Thing { get; set; }
    public string DateStart { get; set; }
    public string? DateEnd { get; set; }

    public Money? PriceGrade1 { get; set; }
    public Money? PriceGrade2 { get; set; }
    public bool IsDeleted { get; set; }

    public bool Remove(DateOnly? dateEnd)
    {
        if (dateEnd is null)
            dateEnd = DateOnly.FromDateTime(DateTime.Now);

        if (dateEnd < DateOnly.FromDateTime(DateTime.Now) || dateEnd < DateStart.ToDate())
            return false;

        DateEnd = dateEnd.ToMyString();
        return true;
    }

    public void Restore()
    {
        IsDeleted = false;
    }

    public bool AddPricingInDate(int priceGrade1, int priceGrade2)
    {
        if (DateStart.ToDate() < DateOnly.FromDateTime(DateTime.Now))
            return false;

        PriceGrade1 = new Money(priceGrade1);
        PriceGrade2 = new Money(priceGrade2);
        Restore();

        return true;

    }

}