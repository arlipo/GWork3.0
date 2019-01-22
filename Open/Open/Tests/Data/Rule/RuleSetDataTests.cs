using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Rule;
namespace Open.Tests.Data.Rule {

    [TestClass] public class RuleSetDataTests : ObjectTests<RuleSetData>
    {
        protected override RuleSetData getRandomObject() {
            return GetRandom.Object<RuleSetData>();
        }
    }
}
