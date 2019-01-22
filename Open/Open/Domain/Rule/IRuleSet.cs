namespace Open.Domain.Rule {
    public interface IRuleSet {
        string RuleSetId { get; set; }
        RuleSet GetRuleSet();
    }
}