using System;
using Open.Aids;
using Open.Data.Quantity;
using Open.Domain.Quantity;
namespace Open.Facade.Quantity {
    public static class RateTypeViewFactory {
        public static RateTypeView Create(RateType o) {
            var v = new RateTypeView {
                Name = o?.Data.Name,
                ID = o?.Data.ID,
                Code = o?.Data.Code,
                Description = o?.Data.Description
            };
            if (o is null) return v;
            v.ValidFrom = Date.SetNullIfMaxOrMin(o.Data?.ValidFrom);
            v.ValidTo = Date.SetNullIfMaxOrMin(o.Data?.ValidTo);
            return v;
        }

        public static RateType Create(RateTypeView c) {
            var o = new RateTypeData {
                ID = c?.ID,
                Name = c?.Name,
                Code = c?.Code,
                Description = c?.Description,
                ValidFrom = c?.ValidFrom ?? DateTime.MinValue,
                ValidTo = c?.ValidTo ?? DateTime.MaxValue
            };
            return new RateType(o);
        }
    }
}

