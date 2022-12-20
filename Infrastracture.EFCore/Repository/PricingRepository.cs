using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pricing_contract.PricingAgg;
using Pricing_Entity;

namespace Infrastracture.EFCore.Repository
{
    public  class PricingRepository : IPricingRepository
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

        public List<PricingShowViewModel> GetFinallPricingList(Expression<Func<PricingThing, bool>> expression)
        {
            return _pricingContext.Categories.SelectMany(x => x.Things , (x,o)=>new {x,o}).SelectMany(mo=>mo.o.pricing , (mo,x) =>new {mo ,x}).Select(
                mod => new PricingShowViewModel
                {
                    DateStart = mod.x.DateStart,
                    PriceGrade1 = mod.x.PriceGrade1!.Value,
                    PriceGrade2 = mod.x.PriceGrade2!.Value,
                    Title = mod.mo.o.Title,
                    TitleCategory = mod.mo.x.TitleCategory
                }).ToList();
        }
    }

}