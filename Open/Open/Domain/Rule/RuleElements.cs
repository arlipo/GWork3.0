//TODO

namespace Open.Domain.Rule {

    //[KnownType(typeof(Operand))] [KnownType(typeof(Operator))]
    //[KnownType(typeof(StringVariable))] [KnownType(typeof(BooleanVariable))]
    //[KnownType(typeof(IntegerVariable))] [KnownType(typeof(DoubleVariable))]
    //[KnownType(typeof(DecimalVariable))] [KnownType(typeof(DateTimeVariable))]
    //[KnownType(typeof(RuleError))] [XmlInclude(typeof(Operand))]
    //[XmlInclude(typeof(Operator))] [XmlInclude(typeof(StringVariable))]
    //[XmlInclude(typeof(BooleanVariable))] [XmlInclude(typeof(IntegerVariable))]
    //[XmlInclude(typeof(DoubleVariable))] [XmlInclude(typeof(DateTimeVariable))]
    //[XmlInclude(typeof(DecimalVariable))] [XmlInclude(typeof(RuleError))]

    public class RuleElements //: Archetypes<RuleElement>
    {

        //public static RuleElements Empty { get; } =
        //    new RuleElements {isReadOnly = true};

        //public static RuleElements Instance { get; } = new RuleElements();

        //public override bool IsEmpty() { return Equals(Empty); }

        //public static bool IsSpecified(RuleElements e) {
        //    if (IsNull(e)) return false;
        //    return e.Count > 0;
        //}

        //public static RuleElements Random() {
        //    var r = new RuleElements();
        //    var count = GetRandom.Count();
        //    for(var i = 0;i < count;i++) { r.Add(RuleElement.Random()); }
        //    r.isChanged = false;
        //    return r;
        //}
    }
}