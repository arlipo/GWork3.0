﻿using Open.Infra.Customers;
using Open.Infra.Goods;

namespace Open.Infra {
    public static class DbInitializer {
        public static void Initialize(SentryDbContext dbContext) {
            GoodsInitializer.Initialize(dbContext);
            CustomersInitializer.Initialize(dbContext);
        }
    }
}


