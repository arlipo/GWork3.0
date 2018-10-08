using System;
namespace Open.Aids {
    public static class Date {
        public static DateTime? SetNullIfMaxOrMin(DateTime? d) {
            if (d is null) return null;
            var dt = (DateTime) d;
            if (dt.Date >= DateTime.MaxValue.Date) return null;
            if (dt.Date <= DateTime.MinValue.AddDays(1).Date) return null;
            return dt;
        }
    }
}
