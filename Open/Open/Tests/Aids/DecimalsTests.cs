using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
namespace Open.Tests.Aids {
    [TestClass] public class DecimalsTests : BaseTests {
        private decimal d1;
        private decimal d2;
        [TestInitialize] public override void TestInitialize() {
            type = typeof(Decimals);
            d1 = GetRandom.Decimal() / 2M;
            d2 = GetRandom.Decimal() / 2M;
        }
        [TestMethod] public void AddTest() {
            Assert.AreEqual(d1 + d2, Decimals.Add(d1, d2));
            Assert.AreEqual(0, Decimals.Add(-d1, d1));
            Assert.AreEqual(0, Decimals.Add(decimal.MinValue, decimal.MaxValue));
            Assert.AreEqual(decimal.MaxValue, Decimals.Add(decimal.MaxValue, decimal.MaxValue));
            Assert.AreEqual(decimal.MaxValue, Decimals.Add(decimal.MinValue, decimal.MinValue));
            var absRandomDecimal = Math.Abs(d1);
            Assert.AreEqual(decimal.MaxValue, Decimals.Add(decimal.MaxValue, absRandomDecimal));
            Assert.AreEqual(decimal.MaxValue - absRandomDecimal,
                Decimals.Add(decimal.MaxValue, -absRandomDecimal));
            Assert.AreEqual(decimal.MinValue + absRandomDecimal,
                Decimals.Add(decimal.MinValue, absRandomDecimal));
            Assert.AreEqual(decimal.MaxValue, Decimals.Add(decimal.MinValue, -absRandomDecimal));
        }
        [TestMethod] public void DivideTest() {
            Assert.AreEqual(d1 / d2, Decimals.Divide(d1, d2));
            Assert.AreEqual(0, Decimals.Divide(decimal.Zero, d1));
            Assert.AreEqual(decimal.MaxValue, Decimals.Divide(d1, decimal.Zero));
        }
        [TestMethod] public void InverseTest() {
            Assert.AreEqual(-d1, Decimals.Inverse(d1));
            Assert.AreEqual(decimal.MinValue, Decimals.Inverse(decimal.MaxValue));
            Assert.AreEqual(decimal.MaxValue, Decimals.Inverse(decimal.MinValue));
        }
        [TestMethod] public void IsEqualTest() {
            Assert.IsTrue(Decimals.IsEqual(decimal.MinValue, decimal.MinValue));
            Assert.IsTrue(Decimals.IsEqual(decimal.MaxValue, decimal.MaxValue));
            Assert.IsTrue(Decimals.IsEqual(d1, d1));
            Assert.IsFalse(Decimals.IsEqual(d1, d2));
        }
        [TestMethod] public void IsGreaterTest() {
            Assert.IsTrue(Decimals.IsGreater(decimal.MaxValue, decimal.MinValue));
            Assert.IsTrue(Decimals.IsGreater(decimal.MaxValue, d1));
            Assert.IsTrue(Decimals.IsGreater(Decimals.Add(decimal.MinValue, 1), decimal.MinValue));
            Assert.IsTrue(Decimals.IsGreater(Decimals.Add(d1, 1), d1));
            Assert.IsFalse(Decimals.IsGreater(decimal.MinValue, d1));
            Assert.IsFalse(Decimals.IsGreater(d1, d1));
        }
        [TestMethod] public void IsLessTest() {
            Assert.IsTrue(Decimals.IsLess(decimal.MinValue, decimal.MaxValue));
            Assert.IsTrue(Decimals.IsLess(d1, decimal.MaxValue));
            Assert.IsTrue(Decimals.IsLess(decimal.MinValue, Decimals.Add(decimal.MinValue, 1)));
            Assert.IsTrue(Decimals.IsLess(Decimals.Add(decimal.MinValue, 1), d1));
            Assert.IsFalse(Decimals.IsLess(d1, Decimals.Add(decimal.MinValue, 1)));
            Assert.IsFalse(Decimals.IsLess(d1, d1));
        }
        [TestMethod] public void MultiplyTest() {
            Assert.AreEqual(decimal.Zero, Decimals.Multiply(decimal.Zero, d1));
            Assert.AreEqual(decimal.Zero, Decimals.Multiply(d1, decimal.Zero));
            Assert.AreEqual(decimal.MaxValue, Decimals.Multiply(d1, decimal.MaxValue));
            Assert.AreEqual(decimal.MaxValue, Decimals.Multiply(d1, decimal.MinValue));
            Assert.AreEqual(d1 * 0.12345M, Decimals.Multiply(d1, 0.12345M));
        }
        [TestMethod] public void ReciprocalTest() {
            Assert.AreEqual(1 / d1, Decimals.Reciprocal(d1));
            Assert.AreEqual(0, Decimals.Reciprocal(decimal.MaxValue));
            Assert.AreEqual(0, Decimals.Reciprocal(decimal.MinValue));
            Assert.AreEqual(decimal.MaxValue, Decimals.Reciprocal(decimal.Zero));
        }
        [TestMethod] public void SubtractTest() {
            Assert.AreEqual(d1 - d2, Decimals.Subtract(d1, d2));
            Assert.AreEqual(0, Decimals.Subtract(d1, d1));
            Assert.AreEqual(0, Decimals.Subtract(decimal.MaxValue, decimal.MaxValue));
            Assert.AreEqual(0, Decimals.Subtract(decimal.MinValue, decimal.MinValue));
            Assert.AreEqual(decimal.MaxValue,
                Decimals.Subtract(decimal.MinValue, decimal.MaxValue));
            Assert.AreEqual(decimal.MaxValue,
                Decimals.Subtract(decimal.MaxValue, decimal.MinValue));
        }
        [TestMethod] public void SquareTest() {
            void test(decimal x) {
                Assert.AreEqual(Decimals.Multiply(x, x), Decimals.Square(x));
            }
            test(d1);
            test(d2);
            test(decimal.MinValue);
            test(decimal.MaxValue);
        }
        [TestMethod] public void ToDecimalTest() {
            var m = GetRandom.Decimal();
            var d = GetRandom.Double(Convert.ToSingle(decimal.MinValue),
                Convert.ToSingle(decimal.MaxValue));
            var f = GetRandom.Float(Convert.ToSingle(decimal.MinValue),
                Convert.ToSingle(decimal.MaxValue));
            var l = GetRandom.Int64();
            var i = GetRandom.Int32();
            var s = GetRandom.Int16();
            var b = GetRandom.Int8();
            var ul = GetRandom.UInt64();
            var ui = GetRandom.UInt32();
            var us = GetRandom.UInt16();
            var ub = GetRandom.UInt8();
            Assert.AreEqual(m, Decimals.ToDecimal(m));
            Assert.AreEqual(Convert.ToDecimal(d), Decimals.ToDecimal(d));
            Assert.AreEqual(Convert.ToDecimal(f), Decimals.ToDecimal(f));
            Assert.AreEqual(Convert.ToDecimal(l), Decimals.ToDecimal(l));
            Assert.AreEqual(Convert.ToDecimal(i), Decimals.ToDecimal(i));
            Assert.AreEqual(Convert.ToDecimal(s), Decimals.ToDecimal(s));
            Assert.AreEqual(Convert.ToDecimal(b), Decimals.ToDecimal(b));
            Assert.AreEqual(Convert.ToDecimal(ul), Decimals.ToDecimal(ul));
            Assert.AreEqual(Convert.ToDecimal(ui), Decimals.ToDecimal(ui));
            Assert.AreEqual(Convert.ToDecimal(us), Decimals.ToDecimal(us));
            Assert.AreEqual(Convert.ToDecimal(ub), Decimals.ToDecimal(ub));
            Assert.AreEqual(1.2345M, Decimals.ToDecimal("1.2345"));
            Assert.AreEqual(1.2345M, Decimals.ToDecimal(1.2345D));
            Assert.AreEqual(1.2345M, Decimals.ToDecimal(1.2345F));
        }
        [TestMethod] public void ToStringTest() {
            void action(decimal x) {
                Assert.AreEqual(x.ToString(UseCulture.Invariant), Decimals.ToString(x));
            }

            action(GetRandom.Decimal());
            action(1234.567m);
            action(1234567m);
            action(123456.7m);
            Assert.AreEqual(d1.ToString(UseCulture.English), Decimals.ToString(d1));
        }
        [TestMethod] public void TryParseTest() {
            void action(decimal x, string s) {
                Assert.IsTrue(Decimals.TryParse(s, out var y));
                Assert.AreEqual(x, y);
            }

            var d = GetRandom.Decimal();
            action(d, d.ToString(UseCulture.Invariant));
            action(1234.567m, "1234.567");
            action(1234567m, "1234,567");
            action(123456.7m, "1234,56.7");
        }
    }
}