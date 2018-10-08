using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Aids.Extensions;
namespace Open.Tests.Aids.Extensions {
    [TestClass] public class DictionaryExtensionsTests : BaseTests {
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(DictionaryExtensions);
        }
        [TestMethod] public void RemoveAllTest() {
            var d = new Dictionary<int, string>();
            var c = GetRandom.UInt8(10, 30);
            for (var i = 0; i < c; i++)
                d.Add(i, GetRandom.String());
            d.RemoveAll(x => x.Key < 10);
            Assert.AreEqual(c - 10, d.Count);
        }
    }
}
