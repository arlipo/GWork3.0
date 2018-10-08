using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
namespace Open.Tests.Core {
    [TestClass] public class RepositoryPageTests : ObjectTests<RepositoryPage> {
        private int pageIndex;
        private int itemsCount;
        private int pageSize;
        private int totalPages;
        private int firstItemIndex;
        protected override RepositoryPage getRandomObject() {
            itemsCount = GetRandom.UInt8(100);
            pageSize = GetRandom.UInt8(2, 10);
            totalPages = (int) Math.Ceiling(itemsCount / (double) pageSize);
            pageIndex = GetRandom.Int32(2, totalPages - 2);
            firstItemIndex = (pageIndex - 1) * pageSize;
            return new RepositoryPage(itemsCount, pageIndex, pageSize);
        }
        [TestMethod] public void DefaultSizeTest() {
            Assert.AreEqual(RepositoryPage.DefaultSize, new RepositoryPage(itemsCount).PageSize);
        }
        [TestMethod] public void PageIndexTest() {
            Assert.AreEqual(1, new RepositoryPage(itemsCount).PageIndex);
            Assert.AreEqual(pageIndex, obj.PageIndex);
        }
        [TestMethod] public void PageSizeTest() {
            Assert.AreEqual(pageSize, obj.PageSize);
        }
        [TestMethod] public void TotalPagesTest() {
            Assert.AreEqual(totalPages, obj.TotalPages);
        }
        [TestMethod] public void FirstItemIndexTest() {
            Assert.AreEqual(firstItemIndex, obj.FirstItemIndex);
        }
    }
}
