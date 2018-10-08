using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Infra;
namespace Open.Tests.Infra
{

    public class DbInitializerTests: BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(DbInitializer);
        }
        [TestMethod] public void InitializeTest() {
            Assert.Inconclusive();
        }
    }
}



