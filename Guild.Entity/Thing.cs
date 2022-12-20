namespace Pricing_Entity;

public class Thing
{
    public Thing(string title, int categoryId, byte profitMargin)
    {
        Title = title;
        CategoryId = categoryId;
        ProfitMargin = profitMargin;
        IsDeleted = false;
        
    }

    public Thing()
    {
        
    }

    public ICollection<PricingThing> pricing { get; private set; }
    public int Id { get; private set; }
    public string Title { get; private set; }
    public Category? Category { get; private set; }
    public int CategoryId { get; private set; }
    public byte ProfitMargin { get; private set; }
    public bool IsDeleted { get; private set; }


    public void Edit(string? title, int? categoryId, byte? profitMargin)
    {
        if (profitMargin is > 0)
            ProfitMargin = profitMargin.Value;

        if (categoryId is > 0)
            CategoryId = categoryId.Value;

        if (!string.IsNullOrWhiteSpace(title))
            Title = title;
    }

    public void Delete()
    {
        IsDeleted = true;
    }

    public void Restore()
    {
        IsDeleted = false;
    }
}