using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Domain.Rule;

namespace Open.Tests.Core {
    [TestClass] public class OperationTests : ClassTests<Operation> {
        [TestMethod] public void IsEnum() { Assert.IsTrue(typeof(Operation).IsEnum); }
        [TestMethod] public void NumberOfElementsTest() {
            Assert.AreEqual(39, GetEnum.Count<Operation>());
        }
        [TestMethod] public void DummyTest() { Assert.AreEqual(0, (int) Operation.Dummy); }
        [TestMethod] public void AndTest() { Assert.AreEqual(1, (int) Operation.And); }
        [TestMethod] public void OrTest() { Assert.AreEqual(2, (int) Operation.Or); }
        [TestMethod] public void XorTest() { Assert.AreEqual(3, (int) Operation.Xor); }
        [TestMethod] public void NotTest() { Assert.AreEqual(4, (int) Operation.Not); }
        [TestMethod] public void EqualTest() { Assert.AreEqual(5, (int) Operation.Equal); }
        [TestMethod] public void GreaterTest() { Assert.AreEqual(6, (int) Operation.Greater); }
        [TestMethod] public void LessTest() { Assert.AreEqual(7, (int) Operation.Less); }
        [TestMethod] public void MonthTest() { Assert.AreEqual(8, (int) Operation.Month); }
        [TestMethod] public void YearTest() { Assert.AreEqual(9, (int) Operation.Year); }
        [TestMethod] public void IntervalTest() { Assert.AreEqual(10, (int) Operation.Interval); }
        [TestMethod] public void SecondsTest() { Assert.AreEqual(11, (int) Operation.Seconds); }
        [TestMethod] public void MinutesTest() { Assert.AreEqual(12, (int) Operation.Minutes); }
        [TestMethod] public void HoursTest() { Assert.AreEqual(13, (int) Operation.Hours); }
        [TestMethod] public void DaysTest() { Assert.AreEqual(14, (int) Operation.Days); }
        [TestMethod] public void AddSecondsTest() {
            Assert.AreEqual(15, (int) Operation.AddSeconds);
        }
        [TestMethod] public void AddMinutesTest() {
            Assert.AreEqual(16, (int) Operation.AddMinutes);
        }
        [TestMethod] public void AddHoursTest() { Assert.AreEqual(17, (int) Operation.AddHours); }
        [TestMethod] public void AddDaysTest() { Assert.AreEqual(18, (int) Operation.AddDays); }
        [TestMethod] public void AddMonthsTest() { Assert.AreEqual(19, (int) Operation.AddMonths); }
        [TestMethod] public void AddYearsTest() { Assert.AreEqual(20, (int) Operation.AddYears); }
        [TestMethod] public void AgeTest() { Assert.AreEqual(21, (int) Operation.Age); }
        [TestMethod] public void LengthTest() { Assert.AreEqual(22, (int) Operation.Length); }
        [TestMethod] public void SubstringTest() { Assert.AreEqual(23, (int) Operation.Substring); }
        [TestMethod] public void ContainsTest() { Assert.AreEqual(24, (int) Operation.Contains); }
        [TestMethod] public void EndsWithTest() { Assert.AreEqual(25, (int) Operation.EndsWith); }
        [TestMethod] public void StartsWithTest() {
            Assert.AreEqual(26, (int) Operation.StartsWith);
        }
        [TestMethod] public void AddTest() { Assert.AreEqual(27, (int) Operation.Add); }
        [TestMethod] public void SubtractTest() { Assert.AreEqual(28, (int) Operation.Subtract); }
        [TestMethod] public void MultiplyTest() { Assert.AreEqual(29, (int) Operation.Multiply); }
        [TestMethod] public void DivideTest() { Assert.AreEqual(30, (int) Operation.Divide); }
        [TestMethod] public void PowerTest() { Assert.AreEqual(31, (int) Operation.Power); }
        [TestMethod] public void InverseTest() { Assert.AreEqual(32, (int) Operation.Inverse); }
        [TestMethod] public void ReciprocalTest() {
            Assert.AreEqual(33, (int) Operation.Reciprocal);
        }
        [TestMethod] public void SquareTest() { Assert.AreEqual(34, (int) Operation.Square); }
        [TestMethod] public void SqrtTest() { Assert.AreEqual(35, (int) Operation.Sqrt); }
        [TestMethod] public void ToUpperTest() { Assert.AreEqual(36, (int) Operation.ToUpper); }
        [TestMethod] public void ToLowerTest() { Assert.AreEqual(37, (int) Operation.ToLower); }
        [TestMethod] public void TrimTest() { Assert.AreEqual(38, (int) Operation.Trim); }
    }
}

