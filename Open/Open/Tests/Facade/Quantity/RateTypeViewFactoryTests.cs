using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Quantity;
using Open.Domain.Quantity;
using Open.Facade.Quantity;
namespace Open.Tests.Facade.Quantity {
    [TestClass] public class RateTypeViewFactoryTests : BaseTests {
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(RateTypeViewFactory);
        }

        [TestMethod] public void CreateTest() {
            var r = GetRandom.Object<RateTypeData>();
            var o = new RateType(r);
            var v = RateTypeViewFactory.Create(o);
            Assert.AreEqual(v.Name, o.Data.Name);
            Assert.AreEqual(v.ValidFrom, o.Data.ValidFrom);
            Assert.AreEqual(v.ValidTo, o.Data.ValidTo);
            Assert.AreEqual(v.ID, o.Data.ID);
            Assert.AreEqual(v.Code, o.Data.Code);
        }
        [TestMethod]
        public void CreateRateTypeTest()
        {
            var r = GetRandom.Object<RateTypeView>();
            r.ValidTo = GetRandom.DateTime(r.ValidFrom);
            var v = RateTypeViewFactory.Create(r);
            Assert.AreEqual(r.Name, v.Data.Name);
            Assert.AreEqual(r.Description, v.Data.Description);
            Assert.AreEqual(r.ValidFrom, v.Data.ValidFrom);
            Assert.AreEqual(r.ValidTo, v.Data.ValidTo);
            Assert.AreEqual(r.ID, v.Data.ID);
            Assert.AreEqual(r.Code, v.Data.Code);
        }
        [TestMethod]
        public void CreateRateTypeWithNullTest() {
            var v = RateTypeViewFactory.Create((RateTypeView)null);
            Assert.AreEqual(Constants.Unspecified, v.Data.Name);
            Assert.AreEqual(Constants.Unspecified, v.Data.Description);
            Assert.AreEqual(DateTime.MinValue, v.Data.ValidFrom);
            Assert.AreEqual(DateTime.MaxValue, v.Data.ValidTo);
            Assert.AreEqual(Constants.Unspecified, v.Data.ID);
            Assert.AreEqual(Constants.Unspecified, v.Data.Code);
        }
    }
}