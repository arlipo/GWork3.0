using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Rule;
namespace Open.Tests.Data.Rule {
    [TestClass] public class OperatorDataTests : ObjectTests<OperatorData>
    {
        protected override OperatorData getRandomObject() {
            return GetRandom.Object<OperatorData>();
        }

        [TestMethod] public void NameTest() {
            obj.Name = GetRandom.String();
            Assert.AreEqual(Operation.Dummy.ToString(), obj.Name);
        }
        [TestMethod] public void OperationTest() {
            Operation op;
            do { op = GetRandom.Enum<Operation>(); } while (op == Operation.Dummy);
            obj.Operation = op;
            Assert.AreEqual(obj.Name, op.ToString());
            Assert.AreEqual(obj.Operation, op);
        }
    }
}
