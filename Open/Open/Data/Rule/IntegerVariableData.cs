using System;
using System.ComponentModel.DataAnnotations.Schema;
using Open.Aids;
namespace Open.Data.Rule {

    public class IntegerVariableData : VariableData<long> {

        protected override string toString(long value) {
            return value.ToString(UseCulture.Invariant);
        }

        protected override string parseValue(string s) {
            Value = Safe.Run(() => long.Parse(s, UseCulture.Invariant), 0);
            return ValueAsString;
        }

    }
}
