using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Rule;
namespace Open.Tests.Data.Rule {
    [TestClass] public class RuleDataTests: ObjectTests<RuleData>
    {
        protected override RuleData getRandomObject() {
            return GetRandom.Object<RuleData>();
        }
    }
}