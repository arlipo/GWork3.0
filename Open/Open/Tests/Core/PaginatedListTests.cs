using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
namespace Open.Tests.Core {
    [TestClass] public class PaginatedListTests : ObjectTests<PaginatedList<string>> {
        private int pageIndex;
        private int itemsCount;
        private int pageSize;
        private int totalPages;
        private RepositoryPage page;
        private RepositoryPage firstPage;
        private RepositoryPage lastPage;
        class testClass : PaginatedList<string> {
            public testClass(RepositoryPage p = null) : base(p) { }
        }
        protected override PaginatedList<string> getRandomObject() {
            itemsCount = GetRandom.UInt8(1, 100);
            pageSize = GetRandom.UInt8(2, 10);
            totalPages = (int) Math.Ceiling(itemsCount / (double) pageSize);
            pageIndex = GetRandom.Int32(2, totalPages - 2);
            page = new RepositoryPage(itemsCount, pageIndex, pageSize);
            firstPage = new RepositoryPage(itemsCount, 1, pageSize);
            lastPage = new RepositoryPage(itemsCount, totalPages, pageSize);
            return new testClass(page);
        }
        [TestMethod] public void IsInstanceOfListTest() {
            Assert.IsInstanceOfType(obj, typeof(List<string>));
        }
        [TestMethod] public void IsInstanceOfPaginatedListTest() {
            Assert.IsInstanceOfType(obj, typeof(IPaginatedList<string>));
        }

        [TestMethod] public void PageIndexTest() {
            Assert.AreEqual(0, new testClass().PageIndex);
            Assert.AreEqual(pageIndex, obj.PageIndex);
        }
        [TestMethod] public void TotalPagesTest() {
            Assert.AreEqual(0, new testClass().TotalPages);
            Assert.AreEqual(totalPages, obj.TotalPages);
        }
        [TestMethod] public void HasPreviousPageTest() {
            Assert.AreEqual(false, new testClass().HasPreviousPage);
            Assert.AreEqual(true, new testClass(lastPage).HasPreviousPage);
            Assert.AreEqual(false, new testClass(firstPage).HasPreviousPage);
        }
        [TestMethod] public void HasNextPageTest() {
            Assert.AreEqual(false, new testClass().HasNextPage);
            Assert.AreEqual(true, obj.HasNextPage);
            Assert.AreEqual(true, new testClass(firstPage).HasNextPage);
            Assert.AreEqual(false, new testClass(lastPage).HasNextPage);
        }
    }
}

