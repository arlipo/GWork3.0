using Open.Data.Common;

namespace Open.Data.Rule {
    public abstract class RuleElementData : PeriodData {

        private string ruleID;
        private string name;
        public virtual string Name {
            get => getString(ref name);
            set => setValue(ref name, value);
        }

        public string RuleID {
            get => getString(ref ruleID);
            set => setValue(ref ruleID, value);
        }

        public virtual RuleData Rule { get; set; }

    }
}

