using System;
using Open.Data.Customers;

namespace Open.Domain.Customers
{
    public static class CustomerFactory
    {
        public static Customer Create(CustomersData data)
        {
            return new Customer(data);
        }
        public static Customer Create(string id, string name, string code, string email, string phone,
            string address, DateTime? validFrom = null, DateTime? validTo = null)
        {
            CustomersData db = new CustomersData
            {
                ID = id,
                Name = name,
                Code = code,
                Email = email,
                Phone = phone,
                Address = address,
                ValidFrom = validFrom ?? DateTime.MinValue,
                ValidTo = validTo ?? DateTime.MaxValue
            };
            return new Customer(db);
        }
    }
}
