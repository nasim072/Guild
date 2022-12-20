using _0_Framework.Common;

namespace Pricing_Entity;

public class PricingThing
{
    public PricingThing( int thingId, DateOnly date )
    {
        ThingId = thingId;
        DateStart = date.ToString();
    
        IsDeleted = true;
    }

    public PricingThing()
    {
        
    }

    public long Id { get; }
    public int ThingId { get; }
    public Thing? Thing { get; }
    public string DateStart { get; private set; }
    public string? DateEnd { get; private set; }

    public Money? PriceGrade1 { get;private set; }
    public Money? PriceGrade2 { get;private set; }
    public bool IsDeleted { get; private set; }

    public bool Remove(DateOnly dateEnd)
    {
        if (dateEnd < DateOnly.FromDateTime(DateTime.Now) || dateEnd<DateStart.ToDate())
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