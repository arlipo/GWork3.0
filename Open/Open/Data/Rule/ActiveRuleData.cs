namespace Open.Data.Rule {
    public class ActiveRuleData : RuleData {

        private string ruleID;

        public string RuleID {
            get => getString(ref ruleID);
            set => setValue(ref ruleID, value);
        }

        public virtual RuleData Rule { get; set; }

    }
}
