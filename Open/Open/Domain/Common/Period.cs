using Open.Core;
using Open.Data.Common;
namespace Open.Domain.Common {
    public abstract class Period<T> : Archetype where T : PeriodData, new() {
        public readonly T Data;
        protected Period(T data) {
            Data = data ?? new T();
        }
    }
}

