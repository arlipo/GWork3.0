using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
namespace Open.Tests.Core {
    [TestClass] public class PartyNameTypeTests : ClassTests<PartyNameType> {
        [TestMethod] public void CountTest() { Assert.AreEqual(6, GetEnum.Count<PartyNameType>()); }
        [TestMethod] public void UndefinedTest() {
            Assert.AreEqual(0, (int) PartyNameType.Undefined);
        }
        [TestMethod] public void OfficialTest() {
            Assert.AreEqual(1, (int) PartyNameType.Official);
        }
        [TestMethod] public void MaidenTest() { Assert.AreEqual(2, (int) PartyNameType.Maiden); }
        [TestMethod] public void NickTest() { Assert.AreEqual(3, (int) PartyNameType.Nick); }
        [TestMethod] public void TradeTest() { Assert.AreEqual(4, (int)PartyNameType.Trade); }
        [TestMethod] public void OtherTest() { Assert.AreEqual(9, (int) PartyNameType.Other); }
    }
}
