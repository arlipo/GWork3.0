using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Quantity;
using Open.Facade.Quantity;
namespace Open.Tests.Facade.Quantity {
    [TestClass] public class MoneyCalculatorViewTests : ObjectTests<MoneyCalculatorView> {

        protected override MoneyCalculatorView getRandomObject() {
            return GetRandom.Object<MoneyCalculatorView>();
        }
        [TestMethod] public void DefaultConstructorTest() {
            var c = new MoneyCalculatorView();
            Assert.IsNotNull(c.Currencies);
        }
        [TestMethod] public void ConstructorTest() {
            var currencies = GetRandom.Object<List<CurrencyData>>();
            var c = new MoneyCalculatorView(currencies);
            Assert.AreNotEqual(0, currencies.Count);
            Assert.AreEqual(currencies.Count, c.Currencies.Count);
            foreach (var x in currencies)
                Assert.IsTrue(c.Currencies.Contains(x.ID), x.ID);
        }
        [TestMethod] public void CurrenciesTest() {
            var p = GetClass.Property<MoneyCalculatorView>(
                GetMember.Name<MoneyCalculatorView>(x => x.Currencies));
            Assert.IsFalse(p.CanWrite);
            Assert.IsTrue(p.CanRead);
        }
        [TestMethod] public void ScoreTest() => canReadWrite(() => obj.Score, x => obj.Score = x);

        [TestMethod] public void ScoreCurrencyTest() =>
            isNullableReadWriteStringProperty(() => obj.ScoreCurrency, x => obj.ScoreCurrency = x);
        [TestMethod] public void RoundingStrategyTest() {
            var c = new MoneyCalculatorView();
            Assert.AreEqual(RoundingStrategy.Round, c.RoundingStrategy);
            canReadWrite(() => obj.RoundingStrategy, x => obj.RoundingStrategy = x);
        }
        [TestMethod] public void RoundingStepTest() {
            var c = new MoneyCalculatorView();
            Assert.AreEqual(MoneyCalculatorView.DefaultRoundingStep, c.RoundingStep);
            canReadWrite(() => obj.RoundingStep, x => obj.RoundingStep = x);
        }
        [TestMethod] public void RoundingDecimalsTest() {
            var c = new MoneyCalculatorView();
            Assert.AreEqual(MoneyCalculatorView.DefaultRoundingDecimals, c.RoundingDecimals);
            canReadWrite(() => obj.RoundingDecimals, x => obj.RoundingDecimals = x);
        }
        [TestMethod] public void RoundingDigitTest() {
            var c = new MoneyCalculatorView();
            Assert.AreEqual(MoneyCalculatorView.DefaultRoundingDigit, c.RoundingDigit);
            canReadWrite(() => obj.RoundingDigit, x => obj.RoundingDigit = x);
        }
        [TestMethod] public void DefaultRoundingStepTest() { }
        [TestMethod] public void DefaultRoundingDecimalsTest() { }
        [TestMethod] public void DefaultRoundingDigitTest() { }
        [TestMethod] public void OperationTest() {
            var c = new MoneyCalculatorView();
            Assert.AreEqual(MoneyOperation.Dummy, c.Operation);
            canReadWrite(() => obj.Operation, x => obj.Operation = x);
        }
        [TestMethod] public void ResultTest() {
            Assert.AreEqual($"{obj.Score} {obj.ScoreCurrency}", obj.Result);
        }
        [TestMethod] public void LoadCurrenciesTest() {
            var currencies = GetRandom.Object<List<CurrencyData>>();
            obj.LoadCurrencies(currencies);
            Assert.AreNotEqual(0, currencies.Count);
            Assert.AreEqual(currencies.Count, obj.Currencies.Count);
            foreach (var x in currencies)
                Assert.IsTrue(obj.Currencies.Contains(x.ID), x.ID);
        }
    }
}
