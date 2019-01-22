using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Rule;
namespace Open.Tests.Data.Rule {
    [TestClass] public class RuleErrorDataTests : ObjectTests<RuleErrorData>
    {
        protected override RuleErrorData getRandomObject() {
            return GetRandom.Object<RuleErrorData>();
        }
    }
}
