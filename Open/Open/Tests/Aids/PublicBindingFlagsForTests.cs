using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
namespace Open.Tests.Aids {

    [TestClass] public class PublicBindingFlagsForTests : BaseTests
    {
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(PublicBindingFlagsFor);
            testType = typeof(testClass);
        }
        private const BindingFlags p = BindingFlags.Public;
        private const BindingFlags i = BindingFlags.Instance;
        private const BindingFlags s = BindingFlags.Static;
        private const BindingFlags d = BindingFlags.DeclaredOnly;
        private Type testType;

        internal class testClass {
            public void Aaa() { bbb(); }
            private void bbb() { }
            public static void Ccc() { ddd(); }
            private static void ddd() { }
        }
        [TestMethod] public void AllMembersTest() {
            testMembers(i | s | p, PublicBindingFlagsFor.AllMembers, 7);
        }
        [TestMethod] public void InstanceMembersTest() {
            testMembers(i | p, PublicBindingFlagsFor.InstanceMembers, 6);
        }
        [TestMethod] public void StaticMembersTest() {
            testMembers(s | p, PublicBindingFlagsFor.StaticMembers, 1);
        }
        [TestMethod] public void DeclaredMembersTest() {
            testMembers(d | i | s | p, PublicBindingFlagsFor.DeclaredMembers, 3);
        }
        private void testMembers(BindingFlags expected, BindingFlags actual,
            int membersCount) {
            var a = testType.GetMembers(actual);
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(membersCount, a.Length);
        }
    }
}



