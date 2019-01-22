//TODO

namespace Open.Domain.Rule {

    public abstract class Variable : Operand {

    //    protected Variable() : this(string.Empty) { }

    //    protected Variable(string name) : base(name) { }

    //    public static Variable Create(string name, object value) {
    //        if (value is double) return new DoubleVariable(name, (double) value);
    //        if (value is int) return new IntegerVariable(name, (int) value);
    //        if (value is decimal) return new DecimalVariable(name, (decimal) value);
    //        if (value is DateTime) return new DateTimeVariable(name, (DateTime) value);
    //        if (value is bool) return new BooleanVariable(name, (bool) value);
    //        var s = value as string;
    //        return new StringVariable(name, s ?? value.ToString());
    //    }

    //    public static IntegerVariable Create(string name, int value) {
    //        return new IntegerVariable(name, value);
    //    }

    //    public static StringVariable Create(string name, string value) {
    //        return new StringVariable(name, value);
    //    }

    //    public static DecimalVariable Create(string name, decimal value) {
    //        return new DecimalVariable(name, value);
    //    }

    //    public static DateTimeVariable Create(string name, DateTime value) {
    //        return new DateTimeVariable(name, value);
    //    }

    //    public static BooleanVariable Create(string name, bool value) {
    //        return new BooleanVariable(name, value);
    //    }

    //    public static DoubleVariable Create(string name, double value) {
    //        return new DoubleVariable(name, value);
    //    }

    //    public static object GetValue(Variable v) {
    //        return GetValue(v as BooleanVariable) ??
    //               GetValue(v as StringVariable) ??
    //               GetValue(v as DateTimeVariable) ??
    //               GetValue(v as IntegerVariable) ??
    //               GetValue(v as DecimalVariable) ??
    //               GetValue(v as DoubleVariable) ?? string.Empty;
    //    }

    //    public static object GetValue(DateTimeVariable v) { return v?.Value; }

    //    public static object GetValue(DoubleVariable v) { return v?.Value; }

    //    public static object GetValue(DecimalVariable v) { return v?.Value; }

    //    public static object GetValue(IntegerVariable v) { return v?.Value; }

    //    public static object GetValue(StringVariable v) { return v?.Value; }

    //    public static object GetValue(BooleanVariable v) { return v?.Value; }

    //    public new static Variable Random() {
    //        var i = GetRandom.Int32() % 6;
    //        switch(i) {
    //            case 1:
    //                return BooleanVariable.Random();
    //            case 2:
    //                return IntegerVariable.Random();
    //            case 3:
    //                return DoubleVariable.Random();
    //            case 4:
    //                return DateTimeVariable.Random();
    //            case 5:
    //                return DecimalVariable.Random();
    //            default:
    //                return StringVariable.Random();
    //        }
    //    }

    //}

    //public abstract class Variable<T> : Variable where T : IComparable {

    //    protected Variable() : this(string.Empty) { }

    //    protected Variable(string name, T value = default(T)) : base(name) {
    //        valueField = value;
    //    }

    //    public virtual T Convert(string s) {
    //        return Safe.Run(() => {
    //            var converter = TypeDescriptor.GetConverter(typeof(T));
    //            return (T)converter.ConvertFromString(s);
    //        },default(T));
    //    }

    //    public virtual bool IsEqual(T variable) {
    //        return Safe.Run(() => Value.CompareTo(variable) == Compare.Equal,
    //            false);
    //    }

    //    public bool IsEqual(Variable<T> v) {
    //        return Safe.Run(() => !IsNull(v) && IsEqual(v.Value),false);
    //    }

    //    public virtual bool IsGreater(T variable) {
    //        return Safe.Run(
    //            () => Value.CompareTo(variable) == Compare.Greater,false);
    //    }

    //    public bool IsGreater(Variable<T> v) {
    //        return Safe.Run(() => !IsNull(v) && IsGreater(v.Value),false);
    //    }

    //    public virtual bool IsLess(T variable) {
    //        return Safe.Run(() => Value.CompareTo(variable) == Compare.Less,
    //            false);
    //    }

    //    public bool IsLess(Variable<T> v) {
    //        return Safe.Run(() => !IsNull(v) && IsLess(v.Value),false);
    //    }

    //    public virtual bool IsNotEqual(T variable) {
    //        return Safe.Run(() => Value.CompareTo(variable) != Compare.Equal,
    //            false);
    //    }

    //    public bool IsNotEqual(Variable<T> v) {
    //        return Safe.Run(() => !IsNull(v) && IsNotEqual(v.Value),false);
    //    }

    //    public virtual bool IsNotGreater(T variable) {
    //        return Safe.Run(
    //            () => Value.CompareTo(variable) != Compare.Greater, false);
    //    }

    //    public bool IsNotGreater(Variable<T> v) {
    //        return Safe.Run(() => !IsNull(v) && IsNotGreater(v.Value),false);
    //    }

    //    public virtual bool IsNotLess(T variable) {
    //        return Safe.Run(() => Value.CompareTo(variable) != Compare.Less,
    //            false);
    //    }

    //    public bool IsNotLess(Variable<T> v) {
    //        return Safe.Run(() => !IsNull(v) && IsNotLess(v.Value), false);
    //    }

    //    public virtual T Value {
    //        get => SetDefault(ref valueField,default(T));
    //        set => SetValue(ref valueField,value);
    //    }

    //    protected T valueField;
    }
}