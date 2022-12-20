using _0_Framework.Application;
using _0_Framework.Common;
using Pricing_contract.PricingAgg;

namespace Pricing_Entity.Pricing.Application;

public class PricingApplication : IPricingApplication
{
    private readonly IPricingRepository _repository;

    public PricingApplication(IPricingRepository repository)
    {
        _repository = repository;
    }

    private PricingThing ReturnPricingThingInDate(int thingId, DateOnly date)
    {
        var result = _repository.GetLastPricingThing(x => x.DateStart.ToDate() == date && x.ThingId == thingId) ??
                     new PricingThing(date: date, thingId: thingId);
        return result;
    }

    public OperationResult PricingByDate(AddPricingRequest request)
    {
        var result = new OperationResult();
        var pricingThingForEndDate = _repository.GetLastPricingThing(x => x.ThingId == request.ThingId) ?? null;
        var newPricingThing = ReturnPricingThingInDate(request.ThingId, request.Date);

        if (newPricingThing.AddPricingInDate(request.PriceGrade1, request.PriceGrade2))
        {
            if (!(newPricingThing.Id > 0))
                _repository.Add(newPricingThing);
            pricingThingForEndDate?.Remove(request.Date);
            _repository.SaveChange();
            result.IsSuccedded = true;
        }
        else result.Message = "مجاز به تغییر قیمت نیستید";

        return result;
    }


    public OperationResult RemovePricingInDate(StopPricingRequest request)
    {
        var result = new OperationResult();
        var pricingThingForEdit = _repository.GetLastPricingThing(x => x.ThingId == request.ThingId);
        if (pricingThingForEdit is null)
        {
            result.Message = "پیدا نشد";
        }
        else if (pricingThingForEdit.Remove(request.DateEnd))
        {
            _repository.SaveChange();
            result.IsSuccedded = true;
        }
        else result.Message = "مجاز به حذف قیمت نیستید";

        return result;
    }

    public OperationResult Restore(int Id)
    {
        throw new NotImplementedException();
    }

    public OperationResult RestoreAll()
    {
        throw new NotImplementedException();
    }

    public IList<PricingThing> GetFinalListPricing(DateOnly? date)
    {
        return _repository.GetPricingThings(x => x.DateEnd == date.ToMyString()).ToList();
    }
}