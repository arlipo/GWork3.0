using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Data.Party;
using Open.Domain.Party;
using Open.Infra;
namespace Open.Tests.Infra
{

    public class RepositoryTests: BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(Repository<Country, CountryData>);
        }
        [TestMethod] public void IsInitializedTest() {
            Assert.Inconclusive();
        }
    }
}


