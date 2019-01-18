using System;
using Open.Core;
using Open.Domain.Goods;

namespace Open.Facade.Goods
{
    public static class GoodViewFactory
    {
        public static GoodView Create(Good o)
        {
            GoodView v = new GoodView
            {
                ID = o?.Data?.ID,
                Name = o?.Data?.Name,
                Code = o?.Data?.Code,
                Type = o?.Data?.Type ?? GoodTypes.Accessories,
                Description = o?.Data?.Description,
                ImgData = o?.Data?.ImgData,
                ImgName = o?.Data?.ImgName,
                Price = o?.Data?.Price
            };
            if (o is null) return v;
            v.ValidFrom = setNullIfExtremum(o.Data.ValidFrom);
            v.ValidTo = setNullIfExtremum(o.Data.ValidTo);
            return v;
        }

        private static DateTime? setNullIfExtremum(DateTime d)
        {
            if (d.Date >= DateTime.MaxValue.Date) return null;
            if (d.Date <= DateTime.MinValue.AddDays(1).Date) return null;
            return d;
        }
    }
}