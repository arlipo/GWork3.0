

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
namespace Open.Tests {
    public abstract class ObjectTests<T> : ClassTests<T> {
        protected T obj;
        private List<Object> list;

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            obj = getRandomObject();
            list = GetClass.ReadWritePropertyValues(obj);
        }

        private void validatePropertyValues() {
            var l = GetClass.ReadWritePropertyValues(obj);
            Assert.AreEqual(l.Count, list.Count);
            for (var i = list.Count; i > 0; i--) {
                var e = l[i - 1];
                Assert.IsTrue(list.Contains(e));
                list.Remove(e);
            }

            Assert.AreEqual(0, list.Count);
        }

        protected virtual T getRandomObject()
        {
            return GetRandom.Object<T>();
        }

        protected void canReadWrite<TR>(Func<TR> get, Action<TR> set) {
            canReadWrite(get, set, () => (TR) GetRandom.Value(typeof(TR)));
        }

        protected void isNullableReadWriteStringProperty(Func<string> get, Action<string> set)
        {
            canReadWrite(get, set);
            allowNullEmptyAndWhitespace(get, set, get);
        }

        protected void isNullableReadWriteProperty<TR>(Func<TR> get, Action<TR> set,
            Func<TR> getRandom) {
            canReadWrite(get, set, getRandom);
            allowNull(get, set);
        }

        protected void canReadWrite<TR>(Func<TR> get, Action<TR> set, Func<TR> getRandom) {
            var x = get();
            Assert.AreEqual(x, get());
            TR y;
            do { y = getRandom(); } while (y.Equals(x));
            set(y);
            Assert.AreEqual(y, get());
            Assert.AreNotEqual(x, y);
            list.Remove(x);
            list.Add(y);
            validatePropertyValues();
        }
        protected void allowNull<TR>(Func<TR> get, Action<TR> set) {
            set(default(TR));
            Assert.AreEqual(get(), null);
        }

        protected void allowNullEmptyAndWhitespace(Func<string> get, Action<string> set,
            Func<string> expected) {
            void test(string s) {
                set(s);
                Assert.AreEqual(get(), expected());
            }
            test(null);
            test(string.Empty);
            test("   ");
        }
        protected void hasAttributes(Expression<Func<T, object>> ex, params Type[] expected) {
            var name = GetMember.Name(ex);
            var p = type.GetProperty(name);
            var actual = p.CustomAttributes.ToArray();
            var msg = $"{name} has different number of attributes";
            Assert.AreEqual(expected.Length, actual.Length, msg);
            foreach (var e in expected) {
                var n = e.Name;
                msg = $"No attribute {n} is defined for {name}";
                var attribute = actual.FirstOrDefault(x => x.AttributeType.Name == n);
                Assert.IsTrue( attribute != null, msg);
            }
        }

        [TestMethod] public void CanCreateTest() { Assert.IsNotNull(obj); }
    }
}







