using System.Linq;
namespace Open.Infra.Customers
{
    public static class CustomersInitializer
    {
        public static void Initialize(SentryDbContext c)
        {
            c.Database.EnsureCreated();
            if (c.Goods.Any()) return;
            //здесь заполняется база данных с клиентами
            c.SaveChanges();
        }
    }
}
