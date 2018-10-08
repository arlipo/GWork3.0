using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Sentry.Models;
namespace Open.Tests.Sentry.Models
{
    [TestClass]
    public class ApplicationUserTests : BaseTests
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            type = typeof(ApplicationUser);
        }

        [TestMethod] public void IsIdentityUserTest() {
            Assert.AreEqual(type.BaseType, typeof(IdentityUser));
        }

    }
}