using Open.Data.Common;
namespace Open.Domain.Common {
    public abstract class Metrics<T> : NamedEntity<T>, IMetrics
        where T : NamedData, new() {
        protected Metrics(T dbRecord) : base(dbRecord) { }
        public string ID => Data.ID;
    }

    //protected Metric() : this(null) { }

    //protected Metric(string name, string symbol = null, string definition = null) : base(name) {
    //    this.name = name ?? string.Empty;
    //    this.symbol = symbol ?? name;
    //    this.definition = definition ?? name;
    //}

    //public string Definition {
    //    get => SetDefault(ref definition);
    //    set => SetValue(ref definition, value);
    //}

    //public virtual string Formula(bool longFormula = false) {
    //    return longFormula ? Name : Symbol;
    //}

    //public static bool IsFormula(string s) { return !IsNull(s) && s.Contains("^"); }

    //public virtual bool IsSameFormula(Metric m) {
    //    if (IsNull(m)) return false;
    //    var f1 = Formula(true);
    //    var f2 = m.Formula(true);
    //    return f1 == f2;
    //}

    //public override bool IsThis(string id) {
    //    if (IsSpaces(id)) return false;
    //    if (UniqueId == id) return true;
    //    if (Name == id) return true;
    //    if (Symbol == id) return true;
    //    if (!IsFormula(id)) return false;
    //    if (Formula() == id) return true;
    //    return Formula(true) == id;
    //}

    //public string Name { get => SetDefault(ref name); set => SetValue(ref name, value); }

    //public string Symbol { get => SetDefault(ref symbol); set => SetValue(ref symbol, value); }

    //protected override void setRandomValues() {
    //    base.setRandomValues();
    //    name = GetRandom.String(5, 10);
    //    symbol = GetRandom.String(3, 5);
    //    definition = GetRandom.String();
    //}

    //private string symbol;
    //private string name;
    //private string definition;

}


