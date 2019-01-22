using Open.Core;

namespace Open.Data.Rule {


    public class RuleOverrideData : Archetype {


        private string ruleContextId;
        private string ruleSetId;

        public string RuleSetId {
            get => getString(ref ruleSetId);
            set => setValue(ref ruleSetId, value);
        }

        public string RuleContextId {
            get => getString(ref ruleContextId);
            set => setValue(ref ruleContextId, value);
        }

        public virtual RuleContextData RuleContext { get; set; }
        public virtual RuleSetData RuleSet { get; set; }

    }
}
