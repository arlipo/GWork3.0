using System;
using Open.Domain.Users;

namespace Open.Facade.Users
{
    public static class UserViewFactory
    {
        public static UserView Create(User o)
        {
            UserView v = new UserView
            {
                ID = o?.Data?.ID,
                Name = o?.Data?.Name,
                Code = o?.Data?.Code,
                Phone = o?.Data?.Phone,
                Address = o?.Data?.Address,
                Login = o?.Data?.Login,
                Password = o?.Data?.Password
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
