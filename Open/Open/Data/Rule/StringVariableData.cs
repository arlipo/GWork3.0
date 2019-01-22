using System.ComponentModel.DataAnnotations.Schema;

namespace Open.Data.Rule {
    public class StringVariableData : VariableData<string> {
        protected override string toString(string s) {
            return s;
        }
        protected override string parseValue(string s) {
            Value = s;
            return ValueAsString;
        }
    }
}
