using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Open.Tests.Tests {
    [TestClass] public class ThreadSafeTests {
        private List<string> values;
        private List<string> threads;
        private readonly object key = new object();
        private const string thread1 = "thread1";
        private const string thread2 = "thread2";
        [TestInitialize] public void TestInitialize() {
            values = new List<string>();
            threads = new List<string>();
        }
        [TestMethod] public void BlockOtherTest() {
            startThreads(addToListBlockOther);
            Assert.AreEqual(values.Count, 10);
            Assert.AreEqual(threads.Count, 1);

        }
        [TestMethod] public void ThreadSafeTest() {
            Assert.Inconclusive("cant get it right in asp.net core 2.1");
            startThreads(addToListSafe);
            Assert.AreEqual(values.Count, 10);
            Assert.AreEqual(threads.Count, 2);
        }
        [TestMethod] public void NotThreadSafeTest() {
            startThreads(addToListNotSafe);
            Assert.IsTrue(values.Count > 10);
            Assert.AreEqual(threads.Count, 2);
        }
        private static void startThreads(Action<string> method) {
            var th1 = new Thread(() => method(thread1));
            var th2 = new Thread(() => method(thread2));
            th1.Start();
            Thread.Sleep(2);
            th2.Start();
            Thread.Sleep(100);
        }
        private void addToListNotSafe(string thread) {
            for (var i = 0; i < 10; i++) { addValue(i, thread); }
        }
        private void addToListSafe(string thread) {
            for (var i = 0; i < 10; i++) {
                lock (key) { addValue(i, thread); }
            }
        }
        private void addToListBlockOther(string thread) {
            lock (key) {
                for (var i = 0; i < 10; i++) { addValue(i, thread); }
            }
        }
        private void addValue(int value, string thread) {
            var s = value.ToString();
            if (values.Find(str => str.StartsWith(s)) == null) {
                Thread.Sleep(2);
                values.Add($"{s} {thread}");
                if (!threads.Contains(thread)) threads.Add(thread);
            }
        }
    }
}



