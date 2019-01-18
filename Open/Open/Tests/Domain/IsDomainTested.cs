using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Open.Tests.Domain {
    [TestClass] public class IsDomainTested : AssemblyTests {
        private const string assembly = "Open.Domain";
        protected override string Namespace(string name) {
            return $"{assembly}.{name}";
        }
        [TestMethod] public void IsCommonTested() {
            isAllTested(assembly, Namespace("Common"));
        }
        [TestMethod]
        public void IsTested()
        {
            isAllTested(base.Namespace("Domain"));
        }

    }
}



