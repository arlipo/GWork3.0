using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
namespace Open.Tests.Aids
{
    [TestClass] public class GetStringTests : BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(GetString);
        }
        [TestMethod] public void HeadTest() {
            Assert.AreEqual("a", GetString.Head("a.b.c"));
            Assert.AreEqual("", GetString.Head(null));
            Assert.AreEqual("", GetString.Head("   "));
            Assert.AreEqual("abc", GetString.Head("abc"));
            Assert.AreEqual("a.b", GetString.Head("a.b,c", ','));
        }
        [TestMethod]
        public void TailTest()
        {
            Assert.AreEqual("b.c", GetString.Tail("a.b.c"));
            Assert.AreEqual("", GetString.Tail(null));
            Assert.AreEqual("", GetString.Tail("   "));
            Assert.AreEqual("abc", GetString.Tail("abc"));
            Assert.AreEqual("c", GetString.Tail("a.b,c", ','));
        }
    }
}




