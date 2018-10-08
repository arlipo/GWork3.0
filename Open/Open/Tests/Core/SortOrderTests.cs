using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
namespace Open.Tests.Core {
    [TestClass] public class SortOrderTests : ClassTests<SortOrder> {
        [TestMethod] public void CountTest() {
            Assert.AreEqual(2, GetEnum.Count<SortOrder>());
        }

        [TestMethod] public void AscendingTest() =>
            Assert.AreEqual(0, (int) SortOrder.Ascending);

        [TestMethod] public void DescendingTest() =>
            Assert.AreEqual(1, (int) SortOrder.Descending);
    }
}


