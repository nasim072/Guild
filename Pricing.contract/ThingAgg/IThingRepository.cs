using Pricing_Entity;
using System.Linq.Expressions;

public interface IThingRepository
{
    void Add(Thing thing);
    void Update(Thing thing);
    bool Exit(Expression<Func<Thing, bool>> expression);
    void SaveChange();
    public void AddNewCategory(Category category);
}