using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Quantity;
using Open.Domain.Quantity;
namespace Open.Tests.Domain.Quantity {
    [TestClass] public class RateTypeTests : EntityBaseTests<RateType, RateTypeData> {
        protected override RateType getRandomObject() {
            createdWithNullArg = new RateType(null);
            dbRecordType = typeof(RateTypeData);
            return GetRandom.Object<RateType>();
        }
    }
}