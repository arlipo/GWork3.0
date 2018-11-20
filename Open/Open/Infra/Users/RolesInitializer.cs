using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Internal;
using Open.Data.Goods;

namespace Open.Infra.Users
{
    public static class RolesInitializer
    {
        public static void Initialize(SentryDbContext c)
        {
            c.Database.EnsureCreated();
            if (c.Goods.Any()) return;

            c.SaveChanges();
        }
        private static string add(SentryDbContext c, GoodsData goods)
        {
            goods.ID = Guid.NewGuid().ToString();
            c.Goods.Add(goods);
            return goods.ID;
        }
    }
}
