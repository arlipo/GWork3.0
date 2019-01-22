//TODO
namespace Open.Domain.Rule {

    //[KnownType(typeof(StringVariable))] [KnownType(typeof(BooleanVariable))]
    //[KnownType(typeof(IntegerVariable))] [KnownType(typeof(DoubleVariable))]
    //[KnownType(typeof(DecimalVariable))] [KnownType(typeof(DateTimeVariable))]
    //[XmlInclude(typeof(StringVariable))] [XmlInclude(typeof(BooleanVariable))]
    //[XmlInclude(typeof(IntegerVariable))] [XmlInclude(typeof(DoubleVariable))]
    //[XmlInclude(typeof(DecimalVariable))] [XmlInclude(typeof(DateTimeVariable))]

    public class RuleOverride //: PartySignature
    {

        //public PartySignatures Authorized {
        //    get => SetDefault(ref authorized);
        //    set => SetValue(ref authorized,value);
        //}

        //public Variable Compute(Rule r) {
        //    return Safe.Run(() => {
        //        if(!IsValidRule(r))
        //            return RuleError.InRule(r.Name);
        //        if(!IsSigned())
        //            return RuleError.NotSigned(r.Name);
        //        if(!IsAuthorized())
        //            return RuleError.NotAuthorized(r.Name);
        //        return Variables.Find(x => x.Name == r.Name) ??
        //               RuleError.Unknown();
        //    },RuleError.Unknown());
        //}

        //public new static RuleOverride Empty { get; } =
        //    new RuleOverride { isReadOnly = true, uniqueId = string.Empty };

        //public RuleSet GetRuleSet => RuleSets.Find(ruleSetId);

        //public bool IsAuthorized() { return Safe.Run(isAuthorized,false); }

        //public override bool IsEmpty() { return Equals(Empty); }

        //public bool IsValid(DateTime? dt = null) {
        //    var d = dt ?? DateTime.Now;
        //    return Valid.IsValid(d);
        //}

        //public bool IsValidRule(Rule r) {
        //    return Variables.Contains(x => x.Name == r.Name);
        //}

        //public new static RuleOverride Random() {
        //    var o = new RuleOverride();
        //    o.setRandomValues();
        //    return o;
        //}

        //public string RuleSetId {
        //    get => SetDefault(ref ruleSetId);
        //    set => SetValue(ref ruleSetId, value);
        //}

        //public Variables Variables {
        //    get => SetDefault(ref variables);
        //    set => SetValue(ref variables, value);
        //}

        //protected override void setRandomValues() {
        //    base.setRandomValues();
        //    variables = Variables.Random();
        //    authorized = PartySignatures.Random();
        //    ruleSetId = GetRandom.String();
        //}

        //private PartySignatures authorized;

        //private bool isAuthorized() {
        //    return Authorized.Any(a => a.IsSigned());
        //}

        //private string ruleSetId;

        //private Variables variables;

    }
}
