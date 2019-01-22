using Open.Aids;

namespace Open.Data.Rule {

    public class DoubleVariableData : VariableData<double> {

        protected override string toString(double value) {
            return value.ToString(UseCulture.Invariant);
        }

        protected override string parseValue(string s) {
            Value = Safe.Run(() => double.Parse(s, UseCulture.Invariant), double.NaN);
            return ValueAsString;
        }
    }
}
