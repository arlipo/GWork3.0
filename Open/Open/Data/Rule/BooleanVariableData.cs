using Open.Aids;
namespace Open.Data.Rule {

    public class BooleanVariableData : VariableData<bool> {
        protected override string toString(bool value) {
            return value.ToString(UseCulture.Invariant);
        }
        protected override string parseValue(string s) {
            Value = Safe.Run(() => bool.Parse(s), false);
            return ValueAsString;
        }
    }

}
