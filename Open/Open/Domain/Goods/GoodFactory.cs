using System;
using Open.Core;
using Open.Data.Goods;

namespace Open.Domain.Goods
{
    public static class GoodFactory
    {
        public static Good Create(GoodsData data)
        {
            return new Good(data);
        }
        
        public static Good Create(string id, string name, string code, string description, string price, 
            GoodTypes type, byte[] image,DateTime? validFrom = null, DateTime? validTo = null)
        {
            GoodsData o = new GoodsData
            {
                ID = id,
                Name = name,
                Code = code,
                Description = description,
                Type = type,
                Price = price,
                Image = image,
                ValidFrom = validFrom ?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue
            };
            return new Good(o);
        }
    }
}