using System;
using Open.Core;
using Open.Domain.Common;
namespace Open.Domain.Quantity {
    public abstract class Value : Archetype, IComparable {
        public abstract int CompareTo(object obj);
    }
    public abstract class Value<TUnit, TAmount, TValue> : Value
        where TUnit : IMetrics
        where TAmount : IConvertible
        where TValue : Value {
        protected string unit;

        protected Value() { }

        protected Value(TUnit u, TAmount amount = default(TAmount)) {
            unit = u == null ? string.Empty : u.ID;
            Amount = amount;
        }

        public TAmount Amount { get; set; }

        public string Unit {
            get => getString(ref unit);
            set => unit = value;
        }

        public abstract TUnit GetUnit();

        public abstract TValue Add(TValue q);

        public abstract int CompareTo(TValue q);

        public abstract TValue ConvertTo(TUnit u);

        public const string DefaultFormat = "{0} {1}";

        public abstract TValue Divide(TAmount d);

        public abstract TValue Multiply(TAmount d);

        public abstract TValue Round(RoundingPolicy policy);

        public abstract TValue Subtract(TValue q);
    }
}
