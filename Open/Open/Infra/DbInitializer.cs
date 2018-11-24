using Open.Infra.Goods;
using Open.Infra.Users;

namespace Open.Infra {
    public static class DbInitializer {
        public static void Initialize(SentryDbContext dbContext) {
            GoodsInitializer.Initialize(dbContext);
            UsersInitializer.Initialize(dbContext);
        }
    }
}


