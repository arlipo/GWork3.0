using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Open.Data.Rule {

    public abstract class BaseVariableData : OperandData {

        [Column("Value")]
        public virtual string ValueAsString { get; set; }

        public string RuleContextID {
            get;
            set;
        }

        public virtual RuleContextData RuleContext
        {
            get;
            set;
        }

    }
}