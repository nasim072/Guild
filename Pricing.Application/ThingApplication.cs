using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using Pricing_contract.ThingAgg;
using Pricing_Entity;

namespace Pricing_Application
{
    public class ThingApplication:IThingApplication
    {
        private readonly IThingRepository _repository;

        public ThingApplication(IThingRepository repository)
        {
            _repository = repository;
        }

        public OperationResult AddNewThing(AddNewThingRequest request)
        {
            var result = new OperationResult();
            var thingForAdding = new Thing(request.Title, request.CategoryId, request.ProfitMargin);
            _repository.Add(thingForAdding);
            result.IsSuccedded = true;
            return result;
        }

        public OperationResult AddNewCategory(AddNewCategoryRequest request)
        {
            var result = new OperationResult();
            var category = new Category(request.TitleCategory);
            result.IsSuccedded = true;
            return result;
        }
    }
}
