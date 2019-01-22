using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Open.Data.Rule {
    public abstract class VariableData<T> : BaseVariableData where T : IComparable {

        [NotMapped]
        public virtual T Value { get; set; }
        public override string ValueAsString {
            get => toString(Value);
            set => parseValue(value);
        }

        protected abstract string toString(T value);
        protected abstract string parseValue(string s);

    }
}