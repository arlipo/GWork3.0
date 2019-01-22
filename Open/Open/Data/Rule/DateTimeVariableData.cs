using System;
using Open.Aids;
namespace Open.Data.Rule {
    public class DateTimeVariableData : VariableData<DateTime> {
        protected override string toString(DateTime value) {
            return value.ToString(UseCulture.Invariant);
        }
        protected override string parseValue(string s) {
            Value = Safe.Run(() => DateTime.Parse(s, UseCulture.Invariant), DateTime.MaxValue);
            return ValueAsString;
        }
    }
}
