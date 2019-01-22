//TODO
namespace Open.Domain.Rule {
    public class RuleSet //: NamedItem
    {

        //private RuleOverrides overrides => RuleOverrides.FindForSet(UniqueId);

        //private RuleUsages ruleUsages => RuleUsages.FindForSet(UniqueId);

        //public RuleUsage AddRule(Rule rule) {
        //    return Safe.Run(() => {
        //        rule = Rules.AddRule(rule);
        //        var u = GetRuleUsages().Find(x => x.RuleId == rule.UniqueId);
        //        if (!IsNull(u)) return u;
        //        u = new RuleUsage {RuleId = rule.UniqueId, RuleSetId = UniqueId};
        //        RuleUsages.Instance.Add(u);
        //        return u;
        //    }, RuleUsage.Empty);
        //}

        //public Variables Compute(RuleContext c, RuleOverride o = null) {
        //    ruleContext = Clone(c);
        //    ruleOverride = IsNull(o) ? null : Clone(o);
        //    var v = new Variables();
        //    foreach (var u in ruleUsages) {
        //        var r = u.GetRule() ?? Rule.Empty;
        //        var e = isOverrided(r.Name) ? r.Compute(ruleOverride) : r.Compute(ruleContext);
        //        v.Add(e);
        //    }
        //    return v;
        //}

        //public new static RuleSet Empty { get; } =
        //    new RuleSet {isReadOnly = true, uniqueId = string.Empty};

        //public RuleOverrides GetOverrides() => overrides;

        //public RuleUsages GetRuleUsages() => ruleUsages;

        //public override bool IsEmpty() { return Equals(Empty); }

        //public new static RuleSet Random() {
        //    var r = new RuleSet();
        //    r.setRandomValues();
        //    return r;
        //}

        //public bool RemoveRule(Rule rule) {
        //    return Safe.Run(() => {
        //        var usages = RuleUsages.FindForSet(UniqueId);
        //        var r = true;
        //        foreach (var usage in usages) {
        //            if (usage.RuleId != rule.UniqueId) continue;
        //            r = r && RuleUsages.Instance.Remove(usage);
        //        }
        //        return r;
        //    }, false);
        //}

        //public bool RemoveRule(RuleUsage rule) {
        //    return Safe.Run(() => {
        //            if (rule.RuleSetId != UniqueId) return false;
        //            var r = RuleUsages.Find(rule.UniqueId);
        //            return RuleUsages.Instance.Remove(r);
        //        },
        //        false);
        //}

        //protected override void setRandomValues() {
        //    base.setRandomValues();
        //    ruleContext = RuleContext.Random();
        //}

        //internal bool isOverrided(string n) {
        //    if (IsNull(ruleOverride)) return false;
        //    if (IsSpaces(n)) return false;
        //    if (ruleOverride.RuleSetId != UniqueId) return false;
        //    return ruleOverride.Variables.Contains(x => x.Name == n);
        //}

        //internal RuleContext ruleContext;

        //internal RuleOverride ruleOverride;

    }
}
