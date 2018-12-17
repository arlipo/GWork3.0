using System;
using Open.Domain.Customers;

namespace Open.Facade.Customers
{
    public static class CustomerViewFactory
    {
        public static CustomerView Create(Customer o)
        {
            var v = new CustomerView
            {
                ID = o?.Data?.ID,
                Name = o?.Data?.Name,
            };
            if (o is null) return v;
            v.ValidFrom = setNullIfExtremum(o.Data.ValidFrom);
            v.ValidTo = setNullIfExtremum(o.Data.ValidTo);
            return v;
        }
        private static DateTime? setNullIfExtremum(DateTime d)
        {
            if (d.Date >= DateTime.MaxValue.Date) return null;
            if (d.Date <= DateTime.MinValue.AddDays(1).Date) return null;
            return d;
        }
    }
}
