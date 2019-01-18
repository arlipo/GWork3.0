﻿



using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Open.Tests.Data
{
    [TestClass]
    public class IsDataTested : AssemblyTests
    {
        private const string assembly = "Open.Data";

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
        public void IsGoodsTested()
        {
            isAllTested(assembly, Namespace("Goods"));
        }

        [TestMethod]
        public void IsShoppingCartTested()
        {
            isAllTested(assembly, Namespace("ShoppingCart"));
        }

        [TestMethod]
        public void IsCustomersTested()
        {
            isAllTested(assembly, Namespace("Customers"));
        }

        [TestMethod]
        public void IsTested()
        {
            isAllTested(base.Namespace("Data"));
        }
    }
}





