using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Quantity;
namespace Open.Tests.Facade.Quantity {
    [TestClass] public class CheckViewTests : ViewTests<CheckView, PaymentMethodView> {
        protected override CheckView getRandomObject() { return GetRandom.Object<CheckView>(); }

        [TestMethod] public void AccountNameTest() {
            canReadWrite(() => obj.AccountName, x => obj.AccountName = x);
        }
        [TestMethod] public void AccountNumberTest() {
            canReadWrite(() => obj.AccountNumber, x => obj.AccountNumber = x);
        }
        [TestMethod] public void CheckNumberTest() {
            canReadWrite(() => obj.CheckNumber, x => obj.CheckNumber = x);
        }
        [TestMethod] public void PayeeTest() {
            canReadWrite(() => obj.Payee, x => obj.Payee = x);
        }
        [TestMethod] public void BankNameTest() {
            canReadWrite(() => obj.BankName, x => obj.BankName = x);
        }
        [TestMethod] public void BankAddressTest() {
            canReadWrite(() => obj.BankAddress, x => obj.BankAddress = x);
        }
        [TestMethod] public void BankIDTest() {
            canReadWrite(() => obj.BankID, x => obj.BankID = x);
        }
        [TestMethod] public void DateWrittenTest() {
            DateTime? rnd() => GetRandom.DateTime(null, obj.ValidTo?.AddYears(-1));
            Assert.AreEqual(obj.ValidFrom , obj.DateWritten);
            obj.DateWritten = rnd();
            Assert.AreEqual(obj.ValidFrom, obj.DateWritten);
        }
        [TestMethod] public void ToStringTest() {
            var s = $"Check ({obj.CheckNumber}, {obj.BankName})";
            Assert.AreEqual(s, obj.ToString());
        }
    }
}
