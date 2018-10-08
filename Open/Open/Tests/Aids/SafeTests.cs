using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
namespace Open.Tests.Aids {
    [TestClass] public class SafeTests : BaseTests {
        private LogTests.testLogBook logBook;
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(Safe);
            logBook = new LogTests.testLogBook();
            Log.logBook = logBook;
        }
        [TestCleanup] public override void TestCleanup() {
            base.TestCleanup();
            Log.logBook = null;
        }
        [TestMethod] public void RunTest() { }
        [TestMethod] public void RunFunctionTest() {
            var actual = Safe.Run(() => "tulemus", "viga");
            Assert.AreEqual("tulemus", actual);
            Assert.IsNull(logBook.LoggedException);
        }
        [TestMethod] public void RunFailingFunctionTest() {
            var actual = Safe.Run(() => throw new NotImplementedException(), "viga");
            Assert.AreEqual("viga", actual);
            var exception = logBook.LoggedException;
            Assert.IsNotNull(exception);
            Assert.IsInstanceOfType(exception, typeof(NotImplementedException));
        }
        [TestMethod] public void RunMethodTest() {
            var newLogBook = new LogTests.testLogBook();
            Safe.Run(() => Log.logBook = newLogBook);
            Assert.IsNull(newLogBook.LoggedException);
        }
        [TestMethod] public void RunFailingMethodTest() {
            Safe.Run(() => throw new ArgumentOutOfRangeException());
            var exception = logBook.LoggedException;
            Assert.IsNotNull(exception);
            Assert.IsInstanceOfType(exception, typeof(ArgumentOutOfRangeException));
        }
        [TestMethod] public void RunInsideRunTest() {
            Safe.Run(() => {
                Safe.Run(() => throw new ArgumentException());
                throw new AggregateException();
            });
            Assert.AreEqual(2, logBook.LoggedExceptions.Count);
            Assert.IsInstanceOfType(logBook.LoggedExceptions[0], typeof(ArgumentException));
            Assert.IsInstanceOfType(logBook.LoggedExceptions[1], typeof(AggregateException));
        }
        [TestMethod] public void RunInsideRunLockedTest() {
            Safe.Run(() => {
                Safe.Run(() => throw new ArgumentException(), true);
                throw new AggregateException();
            }, true);
            Assert.AreEqual(2, logBook.LoggedExceptions.Count);
            Assert.IsInstanceOfType(logBook.LoggedExceptions[0], typeof(ArgumentException));
            Assert.IsInstanceOfType(logBook.LoggedExceptions[1], typeof(AggregateException));
        }
        [TestMethod] public void RunInSeparateThreadsTest() {
            var list = new List<string>();
            startThreads(list);
            validateList(list);
            Assert.AreEqual(2, logBook.LoggedExceptions.Count);
            Assert.IsInstanceOfType(logBook.LoggedExceptions[0], typeof(ArgumentNullException));
            Assert.IsInstanceOfType(logBook.LoggedExceptions[1], typeof(ArithmeticException));
        }
        private static void startThreads(List<string> l) {
            var t1 = new Thread(() =>
                method(l, "method1: ", () => throw new ArgumentNullException()));
            var t2 = new Thread(() =>
                method(l, "method2: ", () => throw new ArithmeticException()));
            t1.Start();
            Thread.Sleep(1);
            t2.Start();
            Thread.Sleep(50);
        }
        private static void method(ICollection<string> list, string message, Action exception) {
            Safe.Run(() => {
                Safe.Run(() => {
                    for (var i = 0; i < 10; i++) {
                        list.Add(message + DateTime.Now);
                        Thread.Sleep(1);
                    }
                    exception();
                }, true);
                list.Add(message + DateTime.Now);
            }, true);
        }
        private static void validateList(List<string> l) {
            Assert.AreEqual(22, l.Count);
            for (var i = 0; i < 22; i++) {
                Assert.IsTrue(
                    i < 11
                        ? l[i].StartsWith("method1:")
                        : l[i].StartsWith("method2:"),
                    string.Format("list[{0}] = {1}", i, l[i]));
            }
        }
    }
}




