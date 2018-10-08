using System;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Data.Party;
using Open.Domain.Party;
using Open.Facade.Party;
namespace Open.Tests.Aids {
    [TestClass] public class GetMemberTests : BaseTests {
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(GetMember);
        }

        [TestMethod] public void NameTest() {
            Assert.AreEqual("Data", GetMember.Name<Country>(o => o.Data));
            Assert.AreEqual("Name", GetMember.Name<CountryData>(o => o.Name));
            Assert.AreEqual("NameTest", GetMember.Name<GetMemberTests>(o => o.NameTest()));
            Assert.AreEqual(string.Empty, GetMember.Name((Expression<Func<CountryData, object>>)null));
            Assert.AreEqual(string.Empty, GetMember.Name((Expression<Action<CountryData>>)null));
        }
        [TestMethod] public void DisplayNameTest() {
            Assert.AreEqual("Data", GetMember.DisplayName<Country>(o => o.Data));
            Assert.AreEqual("Valid From",
                GetMember.DisplayName<CountryView>(o => o.ValidFrom));
            Assert.AreEqual("Name", GetMember.DisplayName<CountryView>(o => o.Name));
            Assert.AreEqual("Valid To", GetMember.DisplayName<CountryView>(o => o.ValidTo));
            Assert.AreEqual(string.Empty, GetMember.DisplayName<CountryView>(null));
            //Impossible to use for methods
            //Assert.AreEqual(string.Empty, GetMember.DisplayName<GetMemberTests>(o => o.NameTest()));
        }
    }
}


