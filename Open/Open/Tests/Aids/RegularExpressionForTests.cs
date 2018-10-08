using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
namespace Open.Tests.Aids {
    [TestClass] public class RegularExpressionForTests : BaseTests {
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(RegularExpressionFor);
        }
        [TestMethod] public void EnglishCapitalsOnlyTest() {
            const string match = RegularExpressionFor.EnglishCapitalsOnly;
            Assert.IsTrue(Regex.IsMatch("ABC", match));
            Assert.IsFalse(Regex.IsMatch("ABc", match));
            Assert.IsFalse(Regex.IsMatch("AB ", match));
            Assert.IsFalse(Regex.IsMatch("AB1", match));
        }
        [TestMethod] public void EnglishTextOnlyTest() {
            const string match = RegularExpressionFor.EnglishTextOnly;
            Assert.IsTrue(Regex.IsMatch("ABC", match));
            Assert.IsTrue(Regex.IsMatch("ABc", match));
            Assert.IsTrue(Regex.IsMatch("AB ", match));
            Assert.IsTrue(Regex.IsMatch("AB'", match));
            Assert.IsTrue(Regex.IsMatch("AB\"", match));
            Assert.IsFalse(Regex.IsMatch("AB1", match));
            Assert.IsFalse(Regex.IsMatch("AB?", match));
            Assert.IsFalse(Regex.IsMatch("aBC", match));
        }
    }
}
