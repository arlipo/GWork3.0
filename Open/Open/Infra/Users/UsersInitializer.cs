using Microsoft.EntityFrameworkCore.Internal;

namespace Open.Infra.Users
{
    public static class UsersInitializer
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
