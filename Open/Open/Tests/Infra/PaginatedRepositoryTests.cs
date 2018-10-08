using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Common;
namespace Open.Tests.Infra {
public abstract class PaginatedRepositoryTests<TObject, TDbRecord> : BaseRepositoryTests<TObject, TDbRecord>
    where TDbRecord : PeriodData
    {
        protected IPaginatedRepository<TObject,TDbRecord> paginatedRepository;
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            paginatedRepository = repository as IPaginatedRepository<TObject, TDbRecord>;
        }
        [TestMethod] public void SearchStringTest() {
            canReadWrite(()=> paginatedRepository.SearchString, x=> paginatedRepository.SearchString=x);
        }
        [TestMethod] public void PageIndexTest() {
            canReadWrite(() => paginatedRepository.PageIndex, x => paginatedRepository.PageIndex = x);
        }
        [TestMethod] public void PageSizeTest() {
            canReadWrite(() => paginatedRepository.PageSize, x => paginatedRepository.PageSize = x);
        }
        [TestMethod] public void SortOrderTest() {
            canReadWrite(() => paginatedRepository.SortOrder, x => paginatedRepository.SortOrder = x);
        }
        [TestMethod] public void SortFunctionTest() {
            canReadWrite(() => paginatedRepository.SortFunction, x => paginatedRepository.SortFunction = x,
                getRandomSortFunction);
        }
        protected abstract Func<TDbRecord, object> getRandomSortFunction();
        [TestMethod] public async Task GetObjectsListTest() {
            await testPageSize();
            await testPageIndex();
            await testSearchString();
            await testSortOrder();
        }
        private async Task testSearchString() {
            await testNotFound();
            await testFound();
        }
        private async Task testFound() {
            var o = getRandomDbRecord();
            dbSet.Add(o);
            db.SaveChanges();
            paginatedRepository.SearchString = getRandomMemberStringValue(o);
            var p = await paginatedRepository.GetObjectsList();
            Assert.AreEqual(1, p.TotalPages, "Pages");
            Assert.AreEqual(false, p.HasNextPage, "Has next");
            Assert.AreEqual(false, p.HasPreviousPage, "Has previous");
            Assert.AreEqual(1, p.PageIndex, "Index");
        }
        private async Task testNotFound() {
            paginatedRepository.SearchString = GetRandom.String();
            var p = await paginatedRepository.GetObjectsList();
            Assert.AreEqual(0, p.PageIndex, "Index");
            Assert.AreEqual(0, p.TotalPages, "Pages");
            Assert.AreEqual(false, p.HasNextPage, "Has next");
            Assert.AreEqual(false, p.HasPreviousPage, "Has previous");
        }
        protected virtual string getRandomMemberStringValue(TDbRecord dbRecord) {
            var b = GetRandom.Bool();
            return b? dbRecord.ValidTo.ToString(CultureInfo.CurrentCulture):
                dbRecord.ValidFrom.ToString(CultureInfo.CurrentCulture);
        }

        private async Task testSortOrder() {
            paginatedRepository.PageSize = 1;
            paginatedRepository.PageIndex = 1;
            paginatedRepository.SearchString = string.Empty;
            paginatedRepository.SortFunction = getRandomSortFunction();
            var p = await paginatedRepository.GetObjectsList();
            Assert.AreEqual(1, p.PageIndex, "Index");
            Assert.AreEqual(dbSet.Count(), p.TotalPages, "Pages");
            Assert.AreEqual(true, p.HasNextPage, "Has next");
            Assert.AreEqual(false, p.HasPreviousPage, "Has previous");
        }
        private async Task testPageIndex() {
            await testFirstPage();
            await testLastPage();
            await testMiddlePage();
        }
        private async Task testMiddlePage() {
            paginatedRepository.PageSize = 1;
            paginatedRepository.PageIndex = dbSet.Count()-1;
            var p = await paginatedRepository.GetObjectsList();
            Assert.AreEqual(dbSet.Count()-1, p.PageIndex, "Index");
            Assert.AreEqual(dbSet.Count(), p.TotalPages, "Pages");
            Assert.AreEqual(true, p.HasNextPage, "Has next");
            Assert.AreEqual(true, p.HasPreviousPage, "Has previous");
        }
        private async Task testLastPage() {
            paginatedRepository.PageSize = 1;
            paginatedRepository.PageIndex = dbSet.Count();
            var p = await paginatedRepository.GetObjectsList();
            Assert.AreEqual(dbSet.Count(), p.PageIndex, "Index");
            Assert.AreEqual(dbSet.Count(), p.TotalPages, "Pages");
            Assert.AreEqual(false, p.HasNextPage, "Has next");
            Assert.AreEqual(true, p.HasPreviousPage, "Has previous");
        }
        private async Task testFirstPage() {
            paginatedRepository.PageSize = 1;
            var p = await paginatedRepository.GetObjectsList();
            Assert.AreEqual(1, p.PageIndex, "Index");
            Assert.AreEqual(dbSet.Count(), p.TotalPages, "Pages");
            Assert.AreEqual(true, p.HasNextPage, "Has next");
            Assert.AreEqual(false, p.HasPreviousPage, "Has previous");
        }
        private async Task testPageSize() {
            paginatedRepository.PageSize = dbSet.Count();
            var p = await paginatedRepository.GetObjectsList();
            Assert.AreEqual(1, p.PageIndex, "Index");
            Assert.AreEqual(1, p.TotalPages, "Pages");
            Assert.AreEqual(false, p.HasNextPage, "Has next");
            Assert.AreEqual(false, p.HasPreviousPage, "Has previous");
        }
    }
}

