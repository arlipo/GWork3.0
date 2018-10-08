using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
namespace Open.Tests.Core {

    [TestClass] public class MessagesTests : BaseTests {

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(Messages);
        }
        [TestMethod] public void ValueIsAlreadyInUseTest() {
            var value = GetRandom.String();
            var member = GetRandom.String();
            var s = string.Format(Messages.ValueIsAlreadyInUse, value, member);
            Assert.IsNotNull(s);
            var valueIndex = s.IndexOf(value, StringComparison.Ordinal);
            var memberIndex = s.IndexOf(member, StringComparison.Ordinal);
            Assert.IsTrue(valueIndex >= 0, s);
            Assert.IsTrue(memberIndex > valueIndex + value.Length, s);
        }
    }
}





