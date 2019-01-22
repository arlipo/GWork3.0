using System;
using System.ComponentModel.DataAnnotations.Schema;
using Open.Aids;
using Open.Core;
namespace Open.Data.Rule {
    public class OperatorData : RuleElementData {

        public override string Name {
            get => Operation.ToString();
            set => Operation = Safe.Run(() => (Operation)Enum.Parse(typeof(Operation), value, true), Operation.Dummy);
        }

        [NotMapped]
        public Operation Operation { get; set; }

    }
}
