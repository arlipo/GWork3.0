using System;
using System.Collections.Generic;
using System.Linq;
using Open.Data.Customers;

namespace Open.Infra.Customers
{
    public static class CustomersInitializer
    {
        public static void Initialize(SentryDbContext c)
        {
            c.Database.EnsureCreated();
            if (c.Goods.Any()) return;
            customersList(c);
            c.SaveChanges();
        }

        private static void customersList(SentryDbContext c)
        {
            var l = new List<string>
            {
                add(c, new CustomersData
                {
                    Name = "Yana",
                    Address = "Sillamäe, Viru19",
                    Code = "1",
                    Email = "yanadrymon@mail.ru",
                    ID = "1",
                    Phone = "5218747"
                }),
                add(c, new CustomersData
                {
                    Name = "YanGo",
                    Address = "Moscow",
                    Code = "2",
                    Email = "yango@gmail.com",
                    ID = "2",
                    Phone = "12345678"
                })
        };
        }
 

    private static string add(SentryDbContext c, CustomersData customers)
        {
            customers.ID = Guid.NewGuid().ToString();
            c.Customers.Add(customers);
            return customers.ID;
        }
    }
}
