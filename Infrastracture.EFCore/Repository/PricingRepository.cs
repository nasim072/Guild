using _0_Framework.Common;
using Microsoft.EntityFrameworkCore;
using Pricing_contract.PricingAgg;
using Pricing_Entity;
using System.Linq.Expressions;

namespace Infrastracture.EFCore.Repository
{
    public class PricingRepository : IPricingRepository
    {
        readonly PricingThingContext _pricingContext;

        public PricingRepository(PricingThingContext pricingContext)
        {
            _pricingContext = pricingContext;
        }


        public PricingThing? GetLastPricingThing(Expression<Func<PricingThing, bool>> expression)
        {
            return _pricingContext.Pricing.LastOrDefault(expression);
        }

        public void Add(PricingThing pricing)
        {
            _pricingContext.Pricing.Add(pricing);
        }

        public void SaveChange()
        {
            _pricingContext.SaveChanges();
        }

        public IQueryable<PricingThing> GetPricingThings(Expression<Func<PricingThing, bool>> expression)
        {
            return _pricingContext.Pricing.Include(x => x.Thing).Where(expression).AsNoTracking();
        }

        public List<Category> GetFinalPricingList(DateOnly? date)
        {
            return _pricingContext.Categories.Include(category => category.Things.Where(thing => thing.PricingThings != null && thing.PricingThings.Count > 0))
                 .ThenInclude(thing => thing.PricingThings.Where(pricingThing => pricingThing.DateEnd == date.ToMyString())).AsNoTracking().ToList();

            //return _pricingContext.Categories.SelectMany(x => x.Things , (x,o)=>new {x,o}).SelectMany(mo=>mo.o.PricingThings , (mo,x) =>new {mo ,x}).Select(
            //    mod => new PricingShowViewModel
            //    {
            //        DateStart = mod.x.DateStart,
            //        PriceGrade1 = mod.x.PriceGrade1!.Value,
            //        PriceGrade2 = mod.x.PriceGrade2!.Value,
            //        Title = mod.mo.o.Title,
            //        TitleCategory = mod.mo.x.TitleCategory
            //    }).ToList();


        }
    }

}