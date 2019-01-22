using Open.Aids;
namespace Open.Data.Rule {
    public class DecimalVariableData : VariableData<decimal> {
        protected override string toString(decimal value)
        {
            return value.ToString(UseCulture.Invariant);
        }
        protected override string parseValue(string s)
        {
            Value = Safe.Run(() => decimal.Parse(s, UseCulture.Invariant), decimal.Zero);
            return ValueAsString;
        }
    }
}
