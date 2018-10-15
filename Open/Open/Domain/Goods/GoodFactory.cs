using System;
using Open.Data.Goods;

namespace Open.Domain.Goods
{
    public static class GoodFactory
    {
        public static Good Create(GoodsData data)
        {
            return new Good(data);
        }
        
        public static Good Create(string id, string name, string code, string describtion, string fileLocation,
            string imageType, string price, DateTime? validFrom = null, DateTime? validTo = null)
        {
            GoodsData db = new GoodsData
            {
                ID = id,
                Name = name,
                Code = code,
                Description = describtion,
                FileLocation = fileLocation,
                ImageType = imageType,
                Price = price,
                ValidFrom = validFrom ?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue
            };
            return new Good(db);
        }
    }
}