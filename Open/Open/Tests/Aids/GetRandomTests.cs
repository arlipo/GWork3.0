using System;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Party;
namespace Open.Tests.Aids {

    [TestClass] public class GetRandomTests : BaseTests {
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(GetRandom);
        }

        private static void doGetRandomTests<T>(Func<T, T, T> funct, T min, T max)
            where T : IComparable {
            doTests(funct, min);
            doTests(funct, max);
            doTests(funct, min, max);
            doTests((x, y) => funct(max, min), min, max);
        }

        private static void doTests<T>(Func<T, T, T> funct, T min, T max) where T : IComparable {
            var l = new List<T>();
            for (var i = 0; i < 10; i++) {
                T r;
                do { r = funct(min, max); } while (l.Contains(r));

                Assert.IsInstanceOfType(r, typeof(T));
                Assert.IsTrue(r.CompareTo(min) >= 0, $"{r} !>= {min}");
                Assert.IsTrue(r.CompareTo(max) <= 0, $"{r} !<= {min}");
                l.Add(r);
            }
        }

        private static void doTests<T>(Func<T, T, T> funct, T x) {
            Assert.AreEqual(x, funct(x, x));
        }

        private static void doTests<T>(Func<T> funct) {
            var l = new List<T>();
            for (var i = 0; i < 10; i++) {
                T r;
                do { r = funct(); } while (l.Contains(r));

                Assert.IsInstanceOfType(r, typeof(T));
                l.Add(r);
            }
        }

        [TestMethod] public void BoolTest() {
            var b = GetRandom.Bool();
            Assert.IsInstanceOfType(b, typeof(bool));
            while (true)
                if (GetRandom.Bool() == !b)
                    return;
        }

        [TestMethod] public void CharTest() {
            doGetRandomTests(GetRandom.Char, 'a', 'z');
            doGetRandomTests(GetRandom.Char, 'A', 'Z');
            doGetRandomTests(GetRandom.Char, char.MinValue, char.MaxValue);
            doGetRandomTests(GetRandom.Char, char.MinValue, (char) (char.MinValue + 100));
            doGetRandomTests(GetRandom.Char, (char) (char.MaxValue - 100), char.MaxValue);
        }

        [TestMethod] public void ColorTest() {
            doTests(GetRandom.Color);
        }


        [TestMethod] public void DateTimeTest() {
            var now = DateTime.Now;
            var min = DateTime.MinValue;
            var max = DateTime.MaxValue;
            doGetRandomTests((x, y) => GetRandom.DateTime(x, y), now.AddYears(-5), now.AddYears(5));
            doGetRandomTests((x, y) => GetRandom.DateTime(x, y), min, min.AddYears(10));
            doGetRandomTests((x, y) => GetRandom.DateTime(x, y), max.AddYears(-10), max);
            doGetRandomTests((x, y) => GetRandom.DateTime(x, y), min, max);
        }

        [TestMethod] public void DecimalTest() {
            var d = 10M;
            doGetRandomTests(GetRandom.Decimal, 100M, 200M);
            doGetRandomTests(GetRandom.Decimal, -200M, 100M);
            doGetRandomTests(GetRandom.Decimal, -400M, -200M);
            doGetRandomTests(GetRandom.Decimal, decimal.MinValue, decimal.MaxValue);
            doGetRandomTests(GetRandom.Decimal, decimal.MinValue, decimal.MinValue / d);
            doGetRandomTests(GetRandom.Decimal, decimal.MaxValue / d, decimal.MaxValue);
        }

        [TestMethod] public void DoubleTest() {
            var d = 100000;
            doGetRandomTests(GetRandom.Double, (double) 10, 110);
            doGetRandomTests(GetRandom.Double, (double) -110, -10);
            doGetRandomTests(GetRandom.Double, (double) -50, 50);
            doGetRandomTests(GetRandom.Double, double.MinValue, double.MaxValue);
            doGetRandomTests(GetRandom.Double, double.MaxValue / d, double.MaxValue);
            doGetRandomTests(GetRandom.Double, double.MinValue, double.MinValue / d);
        }

        [TestMethod] public void EnumTest() {
            var e = GetRandom.Enum<IsoGender>();
            Assert.IsInstanceOfType(e, typeof(IsoGender));
            while (true)
                if (GetRandom.Enum<IsoGender>() != e)
                    return;
        }

        [TestMethod] public void FloatTest() {
            var d = 10F;
            doGetRandomTests(GetRandom.Float, 10F, 110F);
            doGetRandomTests(GetRandom.Float, -110F, -10F);
            doGetRandomTests(GetRandom.Float, -50F, 50F);
            doGetRandomTests(GetRandom.Float, float.MinValue, float.MaxValue);
            doGetRandomTests(GetRandom.Float, float.MaxValue / d, float.MaxValue);
            doGetRandomTests(GetRandom.Float, float.MinValue, float.MinValue / d);
        }

        [TestMethod] public void Int8Test() {
            doGetRandomTests(GetRandom.Int8, (sbyte) 10, (sbyte) 110);
            doGetRandomTests(GetRandom.Int8, (sbyte) -110, (sbyte) -10);
            doGetRandomTests(GetRandom.Int8, (sbyte) -50, (sbyte) 50);
            doGetRandomTests(GetRandom.Int8, sbyte.MinValue, (sbyte) (sbyte.MinValue + 100));
            doGetRandomTests(GetRandom.Int8, (sbyte) (sbyte.MaxValue - 100), sbyte.MaxValue);
            doGetRandomTests(GetRandom.Int8, sbyte.MinValue, sbyte.MaxValue);
        }

        [TestMethod] public void Int16Test() {
            doGetRandomTests(GetRandom.Int16, (short) 100, (short) 200);
            doGetRandomTests(GetRandom.Int16, (short) -200, (short) 100);
            doGetRandomTests(GetRandom.Int16, (short) -400, (short) -200);
            doGetRandomTests(GetRandom.Int16, short.MinValue, (short) (short.MinValue + 200));
            doGetRandomTests(GetRandom.Int16, (short) (short.MaxValue - 100), short.MaxValue);
            doGetRandomTests(GetRandom.Int16, short.MinValue, short.MaxValue);
        }

        [TestMethod] public void Int32Test() {
            doGetRandomTests(GetRandom.Int32, 100, 200);
            doGetRandomTests(GetRandom.Int32, -200, 100);
            doGetRandomTests(GetRandom.Int32, -400, -200);
            doGetRandomTests(GetRandom.Int32, int.MinValue, int.MinValue + 200);
            doGetRandomTests(GetRandom.Int32, int.MaxValue - 100, int.MaxValue);
            doGetRandomTests(GetRandom.Int32, int.MinValue, int.MaxValue);
        }

        [TestMethod] public void Int64Test() {
            var d = 100000000L;
            doGetRandomTests(GetRandom.Int64, (long) 100, 200);
            doGetRandomTests(GetRandom.Int64, (long) -200, 100);
            doGetRandomTests(GetRandom.Int64, (long) -400, -200);
            doGetRandomTests(GetRandom.Int64, long.MinValue, long.MaxValue);
            doGetRandomTests(GetRandom.Int64, long.MinValue, long.MinValue + d);
            doGetRandomTests(GetRandom.Int64, long.MaxValue - d, long.MaxValue);
        }

        [TestMethod] public void StringTest() {
            doTests(() => GetRandom.String());
        }

        [TestMethod] public void TimeSpanTest() {
            doTests(GetRandom.TimeSpan);
        }

        [TestMethod] public void UInt8Test() {
            doGetRandomTests(GetRandom.UInt8, (byte) 10, (byte) 110);
            doGetRandomTests(GetRandom.UInt8, byte.MinValue, (byte) (byte.MinValue + 100));
            doGetRandomTests(GetRandom.UInt8, (byte) (byte.MaxValue - 100), byte.MaxValue);
            doGetRandomTests(GetRandom.UInt8, byte.MinValue, byte.MaxValue);
        }

        [TestMethod] public void UInt16Test() {
            doGetRandomTests(GetRandom.UInt16, (ushort) 100, (ushort) 200);
            doGetRandomTests(GetRandom.UInt16, ushort.MinValue, (ushort) (ushort.MinValue + 200));
            doGetRandomTests(GetRandom.UInt16, (ushort) (ushort.MaxValue - 100), ushort.MaxValue);
            doGetRandomTests(GetRandom.UInt16, ushort.MinValue, ushort.MaxValue);
        }

        [TestMethod] public void UInt32Test() {
            doGetRandomTests(GetRandom.UInt32, (uint) 100, (uint) 200);
            doGetRandomTests(GetRandom.UInt32, uint.MinValue, uint.MinValue + 200);
            doGetRandomTests(GetRandom.UInt32, uint.MaxValue - 100, uint.MaxValue);
            doGetRandomTests(GetRandom.UInt32, uint.MinValue, uint.MaxValue);
        }
        [TestMethod] public void EmailTest() {
            Assert.AreNotEqual(GetRandom.Email(), GetRandom.Email());
        }
        [TestMethod] public void PasswordTest() {
            Assert.AreNotEqual(GetRandom.Password(), GetRandom.Password());
        }

        [TestMethod] public void UInt64Test() {
            var d = 100000000UL;
            doGetRandomTests(GetRandom.UInt64, (ulong) 100, (ulong) 200);
            doGetRandomTests(GetRandom.UInt64, ulong.MinValue, ulong.MaxValue);
            doGetRandomTests(GetRandom.UInt64, ulong.MinValue, ulong.MinValue + d);
            doGetRandomTests(GetRandom.UInt64, ulong.MaxValue - d, ulong.MaxValue);
        }

        [TestMethod] public void ArrayTest() {
            void test(Type x, Type y = null) => Assert.IsInstanceOfType(GetRandom.Array(x), y);
            test(typeof(bool), typeof(bool[]));
            test(typeof(char), typeof(char[]));
            test(typeof(Color), typeof(Color[]));
            test(typeof(int), typeof(int[]));
        }
        [TestMethod] public void ValueTest() {
            void test(Type x, Type y = null) {
                Assert.IsInstanceOfType(GetRandom.Value(x), y ?? x);
                if (y is null) return;
                Assert.IsInstanceOfType(GetRandom.Value(y), y);
            }
            test(typeof(bool?), typeof(bool));
            test(typeof(char?), typeof(char));
            test(typeof(Color?), typeof(Color));
            test(typeof(DateTime?), typeof(DateTime));
            test(typeof(decimal?), typeof(decimal));
            test(typeof(double?), typeof(double));
            test(typeof(IsoGender?), typeof(IsoGender));
            test(typeof(float?), typeof(float));
            test(typeof(sbyte?), typeof(sbyte));
            test(typeof(short?), typeof(short));
            test(typeof(int?), typeof(int));
            test(typeof(long?), typeof(long));
            test(typeof(TimeSpan?), typeof(TimeSpan));
            test(typeof(byte?), typeof(byte));
            test(typeof(ushort?), typeof(ushort));
            test(typeof(uint?), typeof(uint));
            test(typeof(ulong?), typeof(ulong));
            test(typeof(string));
            test(typeof(object));
            test(typeof(CountryData));
        }

        [TestMethod] public void ObjectTest() {
            Assert.IsNull(GetRandom.Object(null));
            var o = GetRandom.Object(typeof(CountryData)) as CountryData;
            Assert.IsNotNull(o);
            Assert.IsFalse(string.IsNullOrWhiteSpace(o.ID));
            Assert.IsFalse(string.IsNullOrWhiteSpace(o.Code));
            Assert.IsFalse(string.IsNullOrWhiteSpace(o.Name));
            var l = GetRandom.Object(typeof(List<int>)) as List<int>;
            Assert.IsNotNull(l);
            Assert.IsTrue(l.Count > 0);
        }
    }
}










