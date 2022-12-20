namespace Pricing_Entity;

public class Category
{
    public Category(string titleCategory)
    {
        TitleCategory = titleCategory;
    }

    public int Id { get; set; }
    public string TitleCategory { get; set; }
    public IList<Thing> Things { get; set; }

}