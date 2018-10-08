using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
namespace Open.Tests.Aids {
    [TestClass] public class SystemEnumerableTests : BaseTests {
        private List<int> list;
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(SystemEnumerable);
            list = new List<int> {1, 3, 2, 4, 1, 6};
        }
        [TestMethod] public void OrderByTest() {
            list = SystemEnumerable.OrderBy(list, x => x.ToString()).ToList();
            Assert.AreEqual(6, list.Count);
            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(1, list[1]);
            Assert.AreEqual(2, list[2]);
            Assert.AreEqual(3, list[3]);
            Assert.AreEqual(4, list[4]);
            Assert.AreEqual(6, list[5]);
        }
        [TestMethod] public void DistinctTest() {
            list = SystemEnumerable.Distinct(list).ToList();
            Assert.AreEqual(5, list.Count);
            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(3, list[1]);
            Assert.AreEqual(2, list[2]);
            Assert.AreEqual(4, list[3]);
            Assert.AreEqual(6, list[4]);
        }
        [TestMethod] public void ConvertTest() {
            var l = SystemEnumerable.Convert(list, x => x.ToString()).ToList();
            Assert.AreEqual(6, l.Count);
            Assert.AreEqual("1", l[0]);
            Assert.AreEqual("3", l[1]);
            Assert.AreEqual("2", l[2]);
            Assert.AreEqual("4", l[3]);
            Assert.AreEqual("1", l[4]);
            Assert.AreEqual("6", l[5]);
        }
        [TestMethod] public void OrderByWithNullArgumentsTest() {
            Assert.AreEqual(0, SystemEnumerable.OrderBy(list, null).Count());
            Assert.AreEqual(0, SystemEnumerable.OrderBy<int>(null, x => x.ToString()).Count());
            Assert.AreEqual(0, SystemEnumerable.OrderBy<int>(null, null).Count());
        }
        [TestMethod] public void DistinctWithNullArgumentsTest() {
            Assert.AreEqual(0, SystemEnumerable.Distinct((IEnumerable<int>) null).Count());
        }
        [TestMethod] public void ConvertWithNullArgumentsTest() {
            Assert.AreEqual(0, SystemEnumerable.Convert<int, string>(list, null).Count());
            Assert.AreEqual(0, SystemEnumerable.Convert<int, string>(null, x => x.ToString()).Count());
            Assert.AreEqual(0, SystemEnumerable.Convert<int, string>(null, null).Count());
        }
    }
}





