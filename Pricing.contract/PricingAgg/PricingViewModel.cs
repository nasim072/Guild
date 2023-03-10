using Pricing_Entity;

namespace Pricing_contract.PricingAgg
{
    public class PricingViewModel
    {
        public string DateStart { get; private set; }
    }

    public class CategoryViewModel
    {
        public string TitleCategory { get; set; }
        public IList<ThingViewModel> Things { get; set; }
    }

    public class ThingViewModel
    {
        public CategoryViewModel Category { get; set; }
        public string Title { get; set; }
        public IList<PricingThing> pricing { get; set; }

    }

    public class PricingShowViewModel
    {
        public string TitleCategory { get; set; }
        public string Title { get; set; }
        public int PriceGrade1 { get; set; }
        public int PriceGrade2 { get; set; }
        public string DateStart { get; set; }
    }
    public class PricingShowViewModelForAll
    {
        public string TitleCategory { get; set; }
        public string Title { get; set; }
        public int PriceGrade1 { get; set; }
        public int PriceGrade2 { get; set; }
        public string DateStart { get; set; }
    }


}