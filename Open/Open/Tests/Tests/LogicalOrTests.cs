using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Open.Tests.Tests {

    [TestClass] public class LogicalOrTests {

        [TestMethod] public void BitwiseOrTest() {
            Assert.AreEqual(12, (int) (BindingFlags.Instance | BindingFlags.Static));
            Assert.AreEqual(12, 4 | 8);
            Assert.AreEqual(true, false | true);
            Assert.AreEqual(12u, 4u | 8u);
            Assert.AreEqual(108, 100 | 8);
        }

        [TestMethod] public void OrIsImpossibleTest() {
            bool or(bool x, bool y) {
                return x || y;
            }
            Assert.AreEqual(false, or(false, false));
            Assert.AreEqual(true, or(true, false));
            // works only for booleans and we cant use for other variables
            //Assert.AreEqual(true, BindingFlags.Instance || BindingFlags.Static);
        }
    }
}

