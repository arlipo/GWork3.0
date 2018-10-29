using System;
using System.Collections.Generic;
using System.Linq;
using Open.Data.Goods;

namespace Open.Infra.Goods
{
    public static class GoodsInitializer
    {
        public static void Initialize(SentryDbContext c)
        {
            c.Database.EnsureCreated();
            if (c.Goods.Any()) return;
            goodsList(c);
            c.SaveChanges();
        }

        private static void goodsList(SentryDbContext c)
        {
            var l = new List<string> {
                add(c, new GoodsData{
                    Name = "Antifreeze + coolant LONG LIFE",
                    Code = "12345",
                    Description = "Organic Acid Technology (OAT) coolant technology that is compatible" +
                                  " for use in all automobiles and light-duty trucks, regardless of make, " +
                                  "model, year or original antifreeze color.",
                    FileLocation = "hz",
                    ID = "1",
                    ImageType = "png",
                    Price = "8,99"
                })
            };
        }
        private static string add(SentryDbContext c, GoodsData goods)
        {
            goods.ID = Guid.NewGuid().ToString();
            c.Goods.Add(goods);
            return goods.ID;
        }
    }
}