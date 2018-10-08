using System;
using Open.Core;
namespace Open.Domain.Common {
    public abstract class Value : Archetype, IComparable {
        public abstract int CompareTo(object obj);
    }
    public abstract class Value<TUnit, TAmount, TValue> : Value
        where TUnit : class, IMetrics, new() 
        where TAmount : IConvertible 
        where TValue : Value {
        public const string DefaultFormat = "{0} {1}";
        protected Value() { }
        protected Value(TUnit u, TAmount amount = default(TAmount)) {
            unit = u?? new TUnit();
            Amount = amount;
        }
        public TAmount Amount { get; set; }
        protected internal TUnit unit { get; }
        public abstract TValue Add(TValue q);
        public abstract int CompareTo(TValue q);
        public abstract TValue ConvertTo(TUnit u);
        public abstract TValue Divide(TAmount d);
        public abstract TValue Multiply(TAmount d);
        public abstract TValue Round(RoundingPolicy policy);
        public abstract TValue Subtract(TValue q);
    }
}