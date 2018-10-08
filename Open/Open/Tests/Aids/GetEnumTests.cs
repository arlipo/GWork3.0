

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
namespace Open.Tests.Aids {

    [TestClass] public class GetEnumTests : BaseTests {
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(GetEnum);
        }

        [TestMethod] public void CountTest() {
            Assert.AreEqual(4, GetEnum.Count<IsoGender>());
            Assert.AreEqual(-1, GetEnum.Count<object>());
        }

        [TestMethod] public void CountByTypeTest() {
            Assert.AreEqual(4, GetEnum.Count(typeof(IsoGender)));
            Assert.AreEqual(-1, GetEnum.Count(typeof(object)));
        }

        [TestMethod] public void ValueByTupeTest() {
            Assert.AreEqual(IsoGender.NotKnown, GetEnum.Value(typeof(IsoGender), 0));
            Assert.AreEqual(IsoGender.Male, GetEnum.Value(typeof(IsoGender), 1));
            Assert.AreEqual(IsoGender.Female, GetEnum.Value(typeof(IsoGender), 2));
            Assert.AreEqual(IsoGender.NotApplicable, GetEnum.Value(typeof(IsoGender), 3));
        }

        [TestMethod] public void ValueTest() {
            Assert.AreEqual(IsoGender.NotKnown, GetEnum.Value<IsoGender>(0));
            Assert.AreEqual(IsoGender.Male, GetEnum.Value<IsoGender>(1));
            Assert.AreEqual(IsoGender.Female, GetEnum.Value<IsoGender>(2));
            Assert.AreEqual(IsoGender.NotApplicable, GetEnum.Value<IsoGender>(3));
        }
    }
}



