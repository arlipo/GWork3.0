using System;
using Open.Core;
namespace Open.Data.Common {
    public abstract class PeriodData : Archetype {

        private DateTime validFrom = DateTime.MinValue;
        private DateTime validTo = DateTime.MaxValue;

        public DateTime ValidFrom {
            get => getMinValue(ref validFrom, ref validTo);
            set => setValue(ref validFrom, value);
        }

        public DateTime ValidTo {
            get => getMaxValue(ref validTo, ref validFrom);
            set => setValue(ref validTo, value);
        }

    }
}


