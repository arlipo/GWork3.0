﻿using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
namespace Open.Tests.Aids {
    [TestClass] public class RegularExpressionForTests : BaseTests {
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(RegularExpressionFor);
        }
        [TestMethod] public void EnglishCapitalsOnlyTest() {
            const string match = RegularExpressionFor.EnglishCapitalsOnly;
            Assert.IsTrue(Regex.IsMatch("ABC", match));
            Assert.IsFalse(Regex.IsMatch("ABc", match));
            Assert.IsFalse(Regex.IsMatch("AB ", match));
            Assert.IsFalse(Regex.IsMatch("AB1", match));
        }
        [TestMethod] public void EnglishTextOnlyTest() {
            const string match = RegularExpressionFor.EnglishTextOnly;
            Assert.IsTrue(Regex.IsMatch("ABC", match));
            Assert.IsTrue(Regex.IsMatch("ABc", match));
            Assert.IsFalse(Regex.IsMatch("AB ", match));
            Assert.IsFalse(Regex.IsMatch("AB'", match));
            Assert.IsFalse(Regex.IsMatch("AB\"", match));
            Assert.IsFalse(Regex.IsMatch("AB1", match));
            Assert.IsFalse(Regex.IsMatch("AB?", match));
            Assert.IsFalse(Regex.IsMatch("aBC", match));
        }

        [TestMethod]
        public void NumericOnlyTest()
        {
            const string match = RegularExpressionFor.NumericOnly;
            Assert.IsTrue(Regex.IsMatch("123", match));
            Assert.IsFalse(Regex.IsMatch("123 ", match));
            Assert.IsFalse(Regex.IsMatch("123a", match));
            Assert.IsFalse(Regex.IsMatch("a123", match));
            Assert.IsFalse(Regex.IsMatch("123'", match));
            Assert.IsFalse(Regex.IsMatch("123\"", match));
        }

        [TestMethod]
        public void PriceTest()
        {
            const string match = RegularExpressionFor.Price;
            Assert.IsTrue(Regex.IsMatch("123", match));
            Assert.IsTrue(Regex.IsMatch("123.1", match));
            Assert.IsFalse(Regex.IsMatch("123 ", match));
            Assert.IsFalse(Regex.IsMatch("123a", match));
            Assert.IsFalse(Regex.IsMatch("a123", match));
            Assert.IsFalse(Regex.IsMatch("123'", match));
            Assert.IsFalse(Regex.IsMatch("123\"", match));
        }
    }
}
