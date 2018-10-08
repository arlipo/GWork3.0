using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
namespace Open.Tests.Aids {
    [TestClass] public class DateTests : BaseTests {
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(Date);
        }

        [TestMethod] public void SetNullIfMaxOrMinTest() {
            var now = DateTime.Now;
            var min = DateTime.MinValue;
            var max = DateTime.MaxValue;
            Assert.AreEqual(now, Date.SetNullIfMaxOrMin(now));
            Assert.AreEqual(null, Date.SetNullIfMaxOrMin(min));
            Assert.AreEqual(null, Date.SetNullIfMaxOrMin(max));
        }
    }
}