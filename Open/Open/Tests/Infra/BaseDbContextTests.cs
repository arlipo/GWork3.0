using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Infra;
namespace Open.Tests.Infra
{
    [TestClass]
    public class BaseDbContextTests : BaseTests
    {

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(BaseDbContext<>);
        }
    }
}
