using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
namespace Open.Tests.Core {
    [TestClass] public class RoundingTests : BaseTests {
        [TestInitialize] public override void TestInitialize() {
            type = typeof(Rounding);
        }
        [TestMethod] public void UpTest() {
            Assert.AreEqual(4.5, Rounding.Up(4.45, 1));
            Assert.AreEqual(4.46, Rounding.Up(4.456, 2));
            Assert.AreEqual(-4.5, Rounding.Up(-4.45, 1));
            Assert.AreEqual(-4.46, Rounding.Up(-4.456, 2));
            Assert.AreEqual(1400, Rounding.Up(1400.00, 2));
        }
        [TestMethod] public void DownTest() {
            Assert.AreEqual(4.4, Rounding.Down(4.45, 1));
            Assert.AreEqual(4.45, Rounding.Down(4.456, 2));
            Assert.AreEqual(-4.4, Rounding.Down(-4.45, 1));
            Assert.AreEqual(-4.45, Rounding.Down(-4.456, 2));
            Assert.AreEqual(1400, Rounding.Down(1400.00, 2));
        }
        [TestMethod] public void OffTest() {
            Assert.AreEqual(4.5, Rounding.Off(4.45, 1, 5));
            Assert.AreEqual(4.45, Rounding.Off(4.456, 2, 7));
            Assert.AreEqual(-4.5, Rounding.Off(-4.45, 1, 5));
            Assert.AreEqual(-4.45, Rounding.Off(-4.456, 2, 7));
            Assert.AreEqual(0.01, Rounding.Off(0.01, 5, 5));
            Assert.AreEqual(0.01, Rounding.Off(0.0100000000002, 5, 5));
            Assert.AreEqual(1, Rounding.Off(0.99999999999999989, 0, 5));
        }
        [TestMethod] public void UpByStepTest() {
            Assert.AreEqual(4.5, Rounding.UpByStep(4.45, 0.25));
            Assert.AreEqual(-4.5, Rounding.UpByStep(-4.45, 0.25));
        }
        [TestMethod] public void DownByStepTest() {
            Assert.AreEqual(4.25, Rounding.DownByStep(4.45, 0.25));
            Assert.AreEqual(-4.25, Rounding.DownByStep(-4.45, 0.25));
        }
        [TestMethod] public void TowardsPositiveTest() {
            Assert.AreEqual(4.5, Rounding.TowardsPositive(4.45, 1));
            Assert.AreEqual(4.46, Rounding.TowardsPositive(4.456, 2));
            Assert.AreEqual(-4.4, Rounding.TowardsPositive(-4.45, 1));
            Assert.AreEqual(-4.45, Rounding.TowardsPositive(-4.456, 2));
        }
        [TestMethod] public void TowardsNegativeTest() {
            Assert.AreEqual(4.4, Rounding.TowardsNegative(4.45, 1));
            Assert.AreEqual(4.45, Rounding.TowardsNegative(4.456, 2));
            Assert.AreEqual(-4.5, Rounding.TowardsNegative(-4.45, 1));
            Assert.AreEqual(-4.46, Rounding.TowardsNegative(-4.456, 2));
        }
        [TestMethod] public void DecimalUpTest() {
            Assert.AreEqual(4.5M, Rounding.Up(4.45M, 1));
            Assert.AreEqual(4.46M, Rounding.Up(4.456M, 2));
            Assert.AreEqual(-4.5M, Rounding.Up(-4.45M, 1));
            Assert.AreEqual(-4.46M, Rounding.Up(-4.456M, 2));
        }
        [TestMethod] public void DecimalDownTest() {
            Assert.AreEqual(4.4M, Rounding.Down(4.45M, 1));
            Assert.AreEqual(4.45M, Rounding.Down(4.456M, 2));
            Assert.AreEqual(-4.4M, Rounding.Down(-4.45M, 1));
            Assert.AreEqual(-4.45M, Rounding.Down(-4.456M, 2));
        }
        [TestMethod] public void DecimalOffTest() {
            Assert.AreEqual(4.5M, Rounding.Off(4.45M, 1, 5));
            Assert.AreEqual(4.45M, Rounding.Off(4.456M, 2, 7));
            Assert.AreEqual(-4.5M, Rounding.Off(-4.45M, 1, 5));
            Assert.AreEqual(-4.45M, Rounding.Off(-4.456M, 2, 7));
            Assert.AreEqual(0.01M, Rounding.Off(0.01M, 5, 5));
            Assert.AreEqual(0.01M, Rounding.Off(0.0100000000002M, 5, 5));
            Assert.AreEqual(1M, Rounding.Off(0.99999999999999989M, 0, 5));
        }
        [TestMethod] public void DecimalUpByStepTest() {
            Assert.AreEqual(4.5M, Rounding.UpByStep(4.45M, 0.25));
            Assert.AreEqual(-4.5M, Rounding.UpByStep(-4.45M, 0.25));
        }
        [TestMethod] public void DecimalDownByStepTest() {
            Assert.AreEqual(4.25M, Rounding.DownByStep(4.45M, 0.25));
            Assert.AreEqual(-4.25M, Rounding.DownByStep(-4.45M, 0.25));
        }
        [TestMethod] public void DecimalTowardsPositiveTest() {
            Assert.AreEqual(4.5M, Rounding.TowardsPositive(4.45M, 1));
            Assert.AreEqual(4.46M, Rounding.TowardsPositive(4.456M, 2));
            Assert.AreEqual(-4.4M, Rounding.TowardsPositive(-4.45M, 1));
            Assert.AreEqual(-4.45M, Rounding.TowardsPositive(-4.456M, 2));
        }
        [TestMethod] public void DecimalTowardsNegativeTest() {
            Assert.AreEqual(4.4M, Rounding.TowardsNegative(4.45M, 1));
            Assert.AreEqual(4.45M, Rounding.TowardsNegative(4.456M, 2));
            Assert.AreEqual(-4.5M, Rounding.TowardsNegative(-4.45M, 1));
            Assert.AreEqual(-4.46M, Rounding.TowardsNegative(-4.456M, 2));
        }
        [TestMethod] public void RoundTest() {
            Func<double, RoundingStrategy, sbyte, byte, double, double> round =
                (x, strategy, percition, digits, step) => {
                    var p = new RoundingPolicy(strategy, percition, digits, step);
                    switch (p.Strategy) {
                        case RoundingStrategy.RoundUp: return Rounding.Up(x, p.Decimals);
                        case RoundingStrategy.RoundDown: return Rounding.Down(x, p.Decimals);
                        case RoundingStrategy.RoundUpByStep: return Rounding.UpByStep(x, p.Step);
                        case RoundingStrategy.RoundDownByStep:
                            return Rounding.DownByStep(x, p.Step);
                        case RoundingStrategy.RoundTowardsPositive:
                            return Rounding.TowardsPositive(x, p.Decimals);
                        case RoundingStrategy.RoundTowardsNegative:
                            return Rounding.TowardsNegative(x, p.Decimals);
                        default: return Rounding.Off(x, p.Decimals, p.Digit);
                    }
                };
            Assert.AreEqual(4.5, round(4.45, RoundingStrategy.RoundUp, 1, GetRandom.UInt8(), GetRandom.Double()));
            Assert.AreEqual(-4.45, round(-4.456, RoundingStrategy.RoundDown, 2, GetRandom.UInt8(), GetRandom.Double()));
            Assert.AreEqual(-4.5, round(-4.45, RoundingStrategy.RoundUpByStep, GetRandom.Int8(), GetRandom.UInt8(), 0.25));
            Assert.AreEqual(4.25, round(4.45, RoundingStrategy.RoundDownByStep, GetRandom.Int8(), GetRandom.UInt8(), 0.25));
            Assert.AreEqual(-4.5, round(-4.45, RoundingStrategy.RoundTowardsNegative, 1, GetRandom.UInt8(), GetRandom.Double()));
            Assert.AreEqual(4.46, round(4.456, RoundingStrategy.RoundTowardsPositive, 2, GetRandom.UInt8(), GetRandom.Double()));
            Assert.AreEqual(4.45, round(4.456, RoundingStrategy.Round, 2, 7, GetRandom.Double()));
        }
    }
}