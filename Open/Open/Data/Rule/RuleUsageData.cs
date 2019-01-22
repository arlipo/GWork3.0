using Open.Data.Common;
namespace Open.Data.Rule {
    public class RuleUsageData : PeriodData {

        private string ruleId;
        private string ruleSetId;

        public string RuleId {
            get => getString(ref ruleId);
            set => setValue(ref ruleId, value);
        }

        public string RuleSetId {
            get => getString(ref ruleSetId);
            set => setValue(ref ruleSetId, value);
        }

        public virtual RuleData Rule { get; set; }
        public virtual RuleSetData RuleSet { get; set; }
    }
}