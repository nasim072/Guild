using _0_Framework.Application;

namespace Pricing_contract.ThingAgg
{
    public interface IThingApplication
    {

        OperationResult AddNewThing(AddNewThingRequest request);
        OperationResult AddNewCategory(AddNewCategoryRequest request);

    }

    public class AddNewCategoryRequest
    {
        public string TitleCategory { get; set; }
    }

    public class AddNewThingRequest
    {
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public byte ProfitMargin { get; set; }
    }

}
