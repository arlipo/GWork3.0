using System;
using System.Linq;
using Open.Aids;
using Open.Core;
using Open.Data.Customers;

namespace Open.Infra.Customers {
    public static class CustomersInitializer {
        public static void Initialize(SentryDbContext c) {
            c.Database.EnsureCreated();
            if (c.Customers.Any()) return;
            initializeCustomers(c);
            c.SaveChanges();
        }
        private static void initializeCustomers(SentryDbContext c) {
            add(c, new CustomersData() {
                Name = "Gunnar Piho"
            });
        }
        private static void add(SentryDbContext c, CustomersData customers) {
            customers.ID = Guid.NewGuid().ToString();
            c.Customers.Add(customers);
        }
    }
}
