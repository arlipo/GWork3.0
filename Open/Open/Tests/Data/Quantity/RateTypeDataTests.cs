using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Common;
using Open.Data.Quantity;
namespace Open.Tests.Data.Quantity {
    [TestClass] public class RateTypeDataTests : ObjectTests<RateTypeData> {
        protected override RateTypeData getRandomObject() {
            return GetRandom.Object<RateTypeData>();
        }

        [TestMethod] public void ConstructorTest() {
            Assert.AreEqual(obj.GetType()
                .BaseType, typeof(NamedData));
        }
        [TestMethod] public void DescriptionTest() {
            canReadWrite(() => obj.Description, x => obj.Description = x);
            allowNullEmptyAndWhitespace(() => obj.Description, x => obj.Description = x,
                () => Constants.Unspecified);
        }
    }
}