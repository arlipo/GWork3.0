//TODO
namespace Open.Domain.Rule {
    public class Rule //: NamedItem
    {

        //private RuleUsages usages => RuleUsages.FindForRule(UniqueId);

        //public Rule() : this(string.Empty) { }

        //public Rule(string name, RuleElements e = null) : base(name) {
        //    uniqueId = name;
        //    Add(e);
        //}

        //public void Add(RuleElements r) {
        //    if (IsNull(r)) return;
        //    Elements.AddRange(r);
        //}

        //public void Add(RuleElement r) { Elements.Add(r); }

        //public virtual Variable Compute(object c) {
        //    context = c as RuleContext;
        //    ruleOverride = c as RuleOverride;
        //    if(!IsNull(ruleOverride))
        //        return compute(ruleOverride);
        //    return !IsNull(context) ? compute() : RuleError.Unknown(Name);
        //}

        //public RuleElements Elements {
        //    get => SetDefault(ref elements);
        //    set => SetValue(ref elements, value);
        //}

        //public new static Rule Empty { get; } = new Rule { isReadOnly = true, uniqueId = string.Empty };

        //public override bool IsChanged() => isChanged || Elements.IsChanged();

        //public override bool IsEmpty() { return Equals(Empty); }

        //public override bool IsSameContent(Common r) {
        //    return IsSameContent(r as Rule);
        //}

        //public bool IsSameContent(Rule r) {
        //    return Safe.Run(() => Elements.IsSameContent(r.Elements), false);
        //}

        //public override bool IsThis(string id) {
        //    if(IsSpaces(id))
        //        return false;
        //    if(id.Equals(UniqueId))
        //        return true;
        //    var e = IsNull(Elements) ? string.Empty : Elements.ToString();
        //    return id.Equals(Name) || id.Equals(e);
        //}

        //public new static Rule Random() {
        //    var v = new Rule();
        //    v.setRandomValues();
        //    return v;
        //}

        //public RuleUsages GetUsages() => usages;

        //protected virtual Variable compute() { return compute(Elements); }

        //protected virtual Variable compute(RuleOverride o) {
        //    return Safe.Run(() => o.Compute(this), RuleError.InOverride(Name));
        //}

        //protected Variable compute(RuleElements e) {
        //    var spec = Clone(e);
        //    if (IsNull(context)) return RuleError.InContext(Name);
        //    if (!RuleElements.IsSpecified(spec)) return RuleError.InRule(Name);
        //    try {
        //        var c = new Calculator();
        //        foreach (var t in spec) compute(c, t);
        //        var r = c.Peek();
        //        return Variable.Create(Name, r);
        //    } catch (Exception ex) {
        //        return Variable.Create(Name, Log.Message(ex));
        //    }
        //}

        //protected override void setRandomValues() {
        //    base.setRandomValues();
        //    elements = RuleElements.Random();
        //}

        //internal void compute(Calculator c, RuleElement e) {
        //    Safe.Run(() => {
        //        var op = e as Operator;
        //        var v = e as Variable;
        //        var o = e as Operand;
        //        if (!IsNull(op)) compute(c, op);
        //        else if (!IsNull(v)) compute(c, v);
        //        else if (!IsNull(o)) compute(c, o);
        //    });
        //}

        //internal static void compute(Calculator c, Variable v) {
        //    c.Set(Variable.GetValue(v));
        //}

        //internal static void compute(Calculator c, Operator o) {
        //    c.Perform(o.Operation);
        //}

        //internal void compute(Calculator c, Operand o) {
        //    var v = context.Find(o) as Variable;
        //    compute(c, v);
        //}

        //internal RuleContext context;

        //internal RuleElements elements;

        //internal RuleOverride ruleOverride;
        //public RuleDao ToDataAccessObject() {
        //    var dao = new RuleDao {
        //        Elements = Elements.ToString(),
        //        Name = Name,
        //        Symbol = Symbol,
        //        Description = Description,
        //        ValidFrom = Valid.From,
        //        ValidTo = Valid.To,
        //        ID = UniqueId
        //    };
        //    return dao;
        //}
    }
}
