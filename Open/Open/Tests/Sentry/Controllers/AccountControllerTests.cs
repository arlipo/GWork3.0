using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Sentry.Controllers;
using Open.Sentry.Data;
using Open.Sentry.Models.AccountViewModels;
namespace Open.Tests.Sentry.Controllers {
    [TestClass] public class AccountControllerTests : AcceptanceTests {
        private ApplicationDbContext appDbContext;
        private RegisterViewModel currrentUser;
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(AccountController);
            var scope = server.Host.Services.CreateScope();
            var services = scope.ServiceProvider;
            appDbContext = services.GetService<ApplicationDbContext>();
        }
        [TestMethod] public async Task LoginTest() {
            var a = GetUrl.ForControllerAction<AccountController>(x => x.Login(null));
            await testControllerAction(a,
                "<h2>Log in</h2>",
                "<form method=\"post\" action=\"/Account/Login\">",
                "<h4>Use a local account to log in.</h4>",
                "<label for=\"Email\">Email</label>",
                "<label for=\"Password\">Password</label>",
                "<label for=\"RememberMe\">",
                "<button type=\"submit\" class=\"btn btn-default\">Log in</button>",
                "<a href=\"/Account/ForgotPassword\">Forgot your password?</a>",
                "<a href=\"/Account/Register\">Register as a new user?</a>"
            );
        }
        [TestMethod] public async Task LoginPostTest() {
            Task validate(object o) => Task.CompletedTask;
            IEnumerable<KeyValuePair<string, string>> createContext(object o) {
                var x = o as LoginViewModel;
                var d = new Dictionary<string, string> {
                    {GetMember.Name<LoginViewModel>(m => m.Email), x?.Email},
                    {GetMember.Name<LoginViewModel>(m => m.Password), x?.Password},
                    {GetMember.Name<LoginViewModel>(m => m.RememberMe), x?.RememberMe.ToString()}
                };
                return d;
            }
            object createObject() {
                var vm = GetRandom.Object<LoginViewModel>();
                vm.Email = currrentUser.Email;
                vm.Password = currrentUser.Password;
                return vm;
            }
            await RegisterPostTest();
            await createAllGivenTest<AccountController>(x => x.Login(null),
                createObject, createContext, validate);
        }
        [TestMethod] public void LoginWith2FaTest() {
            Assert.Inconclusive();
        }
        [TestMethod] public void LoginWithRecoveryCodeTest() {
            Assert.Inconclusive();
        }
        [TestMethod] public void LockoutTest() {
            Assert.Inconclusive();
        }
        [TestMethod] public async Task RegisterTest() {
            var a = GetUrl.ForControllerAction<AccountController>(x => x.Register(null));
            await testControllerAction(a,
                "<h2>Register</h2>",
                "<form method=\"post\" action=\"/Account/Register\">",
                "<h4>Create a new account.</h4>",
                "<label for=\"Email\">Email</label>",
                "<label for=\"Password\">Password</label>",
                "<label for=\"ConfirmPassword\">Confirm password</label>",
                "<button type=\"submit\" class=\"btn btn-default\">Register</button>"
            );
        }
        [TestMethod] public async Task RegisterPostTest() {
            async Task validate(object o) {
                var vm = o as RegisterViewModel;
                Assert.IsNotNull(vm);
                var y = await appDbContext.Users.FirstOrDefaultAsync(x =>
                    x.Email == vm.Email);
                Assert.AreEqual(y.Email, vm.Email);
                currrentUser = vm;
            }
            IEnumerable<KeyValuePair<string, string>> createContext(object o) {
                var x = o as RegisterViewModel;
                var d = new Dictionary<string, string> {
                    {GetMember.Name<RegisterViewModel>(m => m.Email), x?.Email},
                    {GetMember.Name<RegisterViewModel>(m => m.Password), x?.Password},
                    {GetMember.Name<RegisterViewModel>(m => m.ConfirmPassword), x?.ConfirmPassword}
                };
                return d;
            }
            object createObject() {
                var vm = GetRandom.Object<RegisterViewModel>();
                vm.Email = GetRandom.Email();
                vm.Password = GetRandom.Password();
                vm.ConfirmPassword = vm.Password;
                return vm;
            }
            await createAllGivenTest<AccountController>(x => x.Register(null),
                createObject, createContext, validate);
        }
        [TestMethod] public void LogoutTest() {
            Assert.Inconclusive();
        }
        [TestMethod] public void ExternalLoginTest() {
            Assert.Inconclusive();
        }
        [TestMethod] public void ExternalLoginCallbackTest() {
            Assert.Inconclusive();
        }
        [TestMethod] public void ExternalLoginConfirmationTest() {
            Assert.Inconclusive();
        }
        [TestMethod] public void ConfirmEmailTest() {
            Assert.Inconclusive();
        }
        [TestMethod] public void ForgotPasswordTest() {
            Assert.Inconclusive();
        }
        [TestMethod] public void ForgotPasswordConfirmationTest() {
            Assert.Inconclusive();
        }
        [TestMethod] public void ResetPasswordTest() {
            Assert.Inconclusive();
        }
        [TestMethod] public void ResetPasswordConfirmationTest() {
            Assert.Inconclusive();
        }
        [TestMethod] public void AccessDeniedTest() {
            Assert.Inconclusive();
        }
        [TestMethod] public void ErrorMessageTest() {
            Assert.Inconclusive();
        }
        protected async Task createAllGivenTest<T>(
            Expression<Func<T, object>> action,
            Func<object> createRandom,
            Func<object, IEnumerable<KeyValuePair<string, string>>> createHttpPostContext,
            Func<object, Task> validateEntityInRepository,
            bool login = false
        ) where T : Controller {
            var o = createRandom();
            var a = GetUrl.ForControllerAction(action);
            TestAuthenticationHandler.IsLoggedIn = true;
            var response = await client.GetAsync(a);
            response.EnsureSuccessStatusCode();
            var d = createHttpPostContext(o);
            var content = new FormUrlEncodedContent(d);
            TestAuthenticationHandler.IsLoggedIn = login;
            response = await client.PostAsync(a, content);
            Assert.AreEqual(HttpStatusCode.Redirect, response.StatusCode);
            await validateEntityInRepository(o);
        }
    }
}
