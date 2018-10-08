using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
namespace Open.Tests.Aids {
    [TestClass] public class LogTests : BaseTests {
        internal class testLogBook : ILogBook {
            public string LoggedMessage { get; private set; }
            public Exception LoggedException { get; private set; }
            public List<Exception> LoggedExceptions { get; } = new List<Exception>();
            public void WriteEntry(string message) {
                LoggedMessage = message;
            }
            public void WriteEntry(Exception e) {
                LoggedException = e;
                LoggedExceptions.Add(e);
            }
        }
        private testLogBook logBook;
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(Log);
            logBook = new testLogBook();
        }
        [TestCleanup] public override void TestCleanup() {
            base.TestCleanup();
            Log.logBook = null;
        }
        [TestMethod] public void MessageTest() {
            var message = "any message";
            Log.Message(message);
            Assert.IsNull(logBook.LoggedMessage);
            Log.logBook = logBook;
            Log.Message(message);
            Assert.AreEqual(message, logBook.LoggedMessage);
        }
        [TestMethod] public void ExceptionTest() {
            var exception = new NotImplementedException();
            Log.Exception(exception);
            Assert.IsNull(logBook.LoggedException);
            Log.logBook = logBook;
            Log.Exception(exception);
            Assert.AreEqual(exception, logBook.LoggedException);
        }
    }
}





