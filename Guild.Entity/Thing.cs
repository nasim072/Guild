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

    public IList<PricingThing>? PricingThings { get;set; }
    public int Id { get; set; }
    public string Title { get; set; }
    public Category? Category { get; set; }
    public int CategoryId { get;  set; }
    public byte ProfitMargin { get; set; }
    public bool IsDeleted { get; set; }


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