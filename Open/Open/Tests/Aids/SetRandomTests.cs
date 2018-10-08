using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
namespace Open.Tests.Aids {
    [TestClass] public class SetRandomTests : BaseTests {
        internal class testClassA {
            public int A { get; set; }
            public string B { get; set; }
        }
        internal class testClassB {
            public DateTime C { get; set; }
            public testClassA D { get; set; }
        }
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(SetRandom);
        }
        [TestMethod] public void ValuesTest() {
            var o = new testClassA();
            SetRandom.Values(o);
            var x = o.A;
            var y = o.B;
            SetRandom.Values(o);
            Assert.AreNotEqual(x, o.A);
            Assert.AreNotEqual(y, o.B);
        }
        [TestMethod] public void ListValuesTest() {
            var o = new List<testClassA>();
            SetRandom.Values(o);
            Assert.AreNotEqual(0, o.Count);
            for (var i = 0; i < o.Count; i++) {
                Assert.IsInstanceOfType(o[i], typeof(testClassA));
                for (var j = i + 1; j < o.Count; j++) {
                    Assert.AreNotEqual(o[i].A, o[j].A);
                    Assert.AreNotEqual(o[i].B, o[j].B);
                }
            }
        }
        [TestMethod] public void ComposedValuesTest() {
            var o = new testClassB();
            SetRandom.Values(o);
            var x = o.C;
            var y = o.D.A;
            var z = o.D.B;
            SetRandom.Values(o);
            Assert.AreNotEqual(x, o.C);
            Assert.AreNotEqual(y, o.D.A);
            Assert.AreNotEqual(z, o.D.B);
        }
    }
}


