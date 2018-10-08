using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Aids.Extensions;
namespace Open.Tests.Aids.Extensions {
    [TestClass] public class DateExtensionsTests : BaseTests {
        private DateTime d;
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(DateExtensions);
            d = GetRandom.DateTime();
        }
        [TestMethod] public void FirstOfMonthTest() {
            var actual = d.FirstOfMonth();
            var expected = new DateTime(d.Year, d.Month, 1);
            Assert.AreEqual(actual, expected);
        }
        [TestMethod] public void LastOfYearTest() {
            var actual = d.LastOfYear();
            var expected = new DateTime(d.Year, 12, 31);
            Assert.AreEqual(actual, expected);
        }
        [TestMethod] public void LastOfMonthTest() {
            var actual = d.LastOfMonth();
            var expected = new DateTime(d.Year, d.Month, 1).AddMonths(1).AddDays(-1);
            Assert.AreEqual(actual, expected);
        }
        [TestMethod] public void FirstOfWorkingWeekTest() {
            var actual = d.FirstOfWorkingWeek();
            var expected = new DateTime(d.Year, d.Month, d.Day).AddDays(DayOfWeek.Monday - d.DayOfWeek);
            Assert.AreEqual(actual, expected);
        }
        [TestMethod] public void LastOfWorkingWeekTest() {
            var actual = d.LastOfWorkingWeek();
            var expected = new DateTime(d.Year, d.Month, d.Day).AddDays(DayOfWeek.Friday - d.DayOfWeek);
            Assert.AreEqual(actual, expected);
        }
        [TestMethod] public void FirstOfWeekTest() {
            var actual = d.FirstOfWeek();
            var expected = new DateTime(d.Year, d.Month, d.Day).AddDays(DayOfWeek.Sunday - d.DayOfWeek);
            Assert.AreEqual(actual, expected);
        }
        [TestMethod] public void LastOfWeekTest() {
            var actual = d.LastOfWeek();
            var expected = new DateTime(d.Year, d.Month, d.Day).AddDays(DayOfWeek.Saturday - d.DayOfWeek);
            Assert.AreEqual(actual, expected);
        }
        [TestMethod] public void IsWeekEndTest() {
            var actual = d.IsWeekEnd();
            var expected = d.DayOfWeek == DayOfWeek.Saturday || d.DayOfWeek == DayOfWeek.Sunday;
            Assert.AreEqual(actual, expected);
        }
    }
}
