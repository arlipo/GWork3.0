



using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Open.Tests.Aids
{
    [TestClass]
    public class IsAidsTested : AssemblyTests
    {
        private const string assembly = "Open.Aids";
        protected override string Namespace(string name)
        {
            return $"{assembly}.{name}";
        }
        [TestMethod]
        public void IsExtensionsTested()
        {
            isAllTested(assembly, Namespace("Extensions"));
        }
        [TestMethod] public void IsTested() { isAllTested(base.Namespace("Aids")); }
    }
}



