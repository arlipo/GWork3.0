using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Open.Tests.Sentry
{
    [TestClass]
    public class IsSentryTested : AssemblyTests
    {
        private const string assembly = "Open.Sentry";
        protected override string Namespace(string name)
        {
            return $"{assembly}.{name}";
        }
        [TestMethod]
        public void IsControllersTested()
        {
            isAllTested(assembly, Namespace("Controllers"));
        }
        [TestMethod]
        public void IsDataTested()
        {
            isAllTested(assembly, Namespace("Data"));
        }
        [TestMethod]
        public void IsExtensionsTested()
        {
            isAllTested(assembly, Namespace("Extensions"));
        }
        [TestMethod]
        public void IsModelsTested()
        {
            isAllTested(assembly, Namespace("Models"));
        }
        [TestMethod]
        public void IsServicesTested()
        {
            isAllTested(assembly, Namespace("Services"));
        }
        [TestMethod]
        public void IsViewsTested()
        {
            isAllTested(assembly, Namespace("Views"));
        }
        [TestMethod]
        public void IsTested()
        {
            isAllTested(base.Namespace("Sentry"));
        }
    }
}





