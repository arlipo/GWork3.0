using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids.Extensions;
using Open.Core;
namespace Open.Tests.Aids.Extensions {
    [TestClass] public class EnumExtensionsTests : BaseTests {
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(EnumExtensions);
        }
        [TestMethod] public void DescriptionTest() {
            Assert.AreEqual("Not Known", IsoGender.NotKnown.Description());
            Assert.AreEqual("Female", IsoGender.Female.Description());
            Assert.AreEqual("Male", IsoGender.Male.Description());
            Assert.AreEqual("Not Applicable", IsoGender.NotApplicable.Description());
        }
    }
}
