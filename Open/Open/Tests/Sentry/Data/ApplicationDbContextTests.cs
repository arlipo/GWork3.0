using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Sentry.Data;
namespace Open.Tests.Sentry.Data
{
    [TestClass] public class ApplicationDbContextTests: BaseTests
    {
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(ApplicationDbContext);
        } 
    }
}
