using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids.Extensions;
using Open.Core;
namespace Open.Tests.Aids.Extensions {
    [TestClass] public class TypeExtensionsTests : BaseTests {
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(TypeExtensions);
        }
        [TestMethod] public void IsNumericTest() {
            Assert.IsTrue(typeof(byte).IsNumeric());
            Assert.IsTrue(typeof(decimal).IsNumeric());
            Assert.IsTrue(typeof(double).IsNumeric());
            Assert.IsTrue(typeof(short).IsNumeric());
            Assert.IsTrue(typeof(int).IsNumeric());
            Assert.IsTrue(typeof(long).IsNumeric());
            Assert.IsTrue(typeof(sbyte).IsNumeric());
            Assert.IsTrue(typeof(float).IsNumeric());
            Assert.IsTrue(typeof(ushort).IsNumeric());
            Assert.IsTrue(typeof(uint).IsNumeric());
            Assert.IsTrue(typeof(ulong).IsNumeric());
            Assert.IsTrue(typeof(byte?).IsNumeric());
            Assert.IsTrue(typeof(decimal?).IsNumeric());
            Assert.IsTrue(typeof(double?).IsNumeric());
            Assert.IsTrue(typeof(short?).IsNumeric());
            Assert.IsTrue(typeof(int?).IsNumeric());
            Assert.IsTrue(typeof(long?).IsNumeric());
            Assert.IsTrue(typeof(sbyte?).IsNumeric());
            Assert.IsTrue(typeof(float?).IsNumeric());
            Assert.IsTrue(typeof(ushort?).IsNumeric());
            Assert.IsTrue(typeof(uint?).IsNumeric());
            Assert.IsTrue(typeof(ulong?).IsNumeric());
            Assert.IsFalse(typeof(bool).IsNumeric());
            Assert.IsFalse(typeof(bool?).IsNumeric());
            Assert.IsFalse(typeof(DateTime).IsNumeric());
            Assert.IsFalse(typeof(DateTime?).IsNumeric());
            Assert.IsFalse(typeof(string).IsNumeric());
            Assert.IsFalse(typeof(object).IsNumeric());
            Assert.IsFalse(typeof(IsoGender).IsNumeric());
        }

    }
}
