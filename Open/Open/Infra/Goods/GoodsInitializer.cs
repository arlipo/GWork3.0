using System.Linq;

namespace Open.Infra.Goods
{
    public static class GoodsInitializer
    {
        public static void Initialize(SentryDbContext c)
        {
            c.Database.EnsureCreated();
            if (c.Goods.Any()) return;
            //здесь заполняется база данных с товарами
            c.SaveChanges();
        }
    }
}