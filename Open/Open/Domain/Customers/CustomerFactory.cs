using System;
using Open.Core;
using Open.Data.Customers;

namespace Open.Domain.Customers
{
    public static class CustomerFactory
    {
        public static Customer Create(CustomersData data)
        {
            return new Customer(data);
        }

        public static Customer Create(string id, string name, DateTime? validFrom = null, DateTime? validTo = null)
        {
            CustomersData o = new CustomersData
            {
                ID = id,
                Name = name,
                ValidFrom = validFrom ?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue
            };
            return new Customer(o);
        }
    }
}
