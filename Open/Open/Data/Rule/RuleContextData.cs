using Open.Data.Common;
namespace Open.Data.Rule {
    public class RuleContextData : NamedData {

        private string ruleID;
        private string ruleSetID;

        public string RuleID {
            get => getString(ref ruleID);
            set => setValue(ref ruleID, value);
        }

        public string RuleSetID {
            get => getString(ref ruleSetID);
            set => setValue(ref ruleSetID, value);
        }

        public virtual RuleSetData RuleSet { get; set; }
        public virtual RuleData Rule { get; set; }
    }
}
