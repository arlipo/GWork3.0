using Open.Data.Rule;
namespace Open.Infra.Rule {
    public static class RulesDbInitializer {
        public static void Initialize(RulesDbContext dbContext) { }
        public static void AddRule(RulesDbContext c, string name) {
            c.Rules.Add(new RuleData { Name = name });
        }
        public static void AddRuleElement(RulesDbContext c, RuleElementData ruleElement) {
            c.RuleElements.Add(ruleElement);
        }
    }
}
