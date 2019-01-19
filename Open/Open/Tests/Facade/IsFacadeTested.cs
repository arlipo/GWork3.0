using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Open.Tests.Facade
{
    [TestClass]
    public class IsFacadeTested : AssemblyTests
    {
        private const string assembly = "Open.Facade";

        protected override string Namespace(string name)
        {
            return $"{assembly}.{name}";
        }

        [TestMethod]
        public void IsCommonTested()
        {
            isAllTested(assembly, Namespace("Common"));
        }

        [TestMethod]
        public void IsTested()
        {
            isAllTested(base.Namespace("Facade"));
        }

        [TestMethod]
        public void IsShoppingCartTested()
        {
            isAllTested(assembly, Namespace("ShoppingCart"));
        }

        [TestMethod]
        public void IsGoodsTested()
        {
            isAllTested(assembly, Namespace("Goods"));
        }

        [TestMethod]
        public void IsCustomersTested()
        {
            isAllTested(assembly, Namespace("Customers"));
        }
    }
}


