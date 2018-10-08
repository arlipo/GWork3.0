using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Core;
using Open.Data.Common;
using Open.Sentry.Controllers;
namespace Open.Tests.Sentry.Controllers {
    public abstract class BaseControllerTests<TController, TObject, TRecord> : AcceptanceTests
        where TRecord : IdentifiedData, new()
        where TController : Controller, ISentryController {
        protected IRepository<TObject, TRecord> repository { get; set; }
        protected string controller { get; set; }
        protected string actualEditAction { get; set; } = "edit";
        protected string detailsViewCaption { get; set; }
        protected string editViewCaption { get; set; }
        protected List<string> specificStringsToTestInView { get; set; }
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(TController);
            generateRandomDbRecords();
        }
        private void generateRandomDbRecords()
        {
            for (var i = 0; i < GetRandom.UInt8(15, 20); i++)
                createDbRecord();
        }
        protected virtual string createDbRecord() => string.Empty;
        [TestMethod] public async Task IndexTest() {
            var a = GetUrl.ForControllerAction<TController>(x => x.Index(null, null, null, null));
            await testWhenLoggedOut(a, HttpStatusCode.Unauthorized);
            var strings = new List<string> {
                $"<form method=\"get\" action=\"/{controller}\"",
                "<div class=\"form-inline col-md-6\">",
                "Find by: <input class=\"form-control\" type=\"text\" name=\"SearchString\"",
                "<input type=\"submit\" value=\"Search\" class=\"btn btn-default\" /> |",
                $"<a href=\"/{controller}\">Back to Full List</a>",
                "<table class=\"table\">",
                "<thead>",
                $"<a class=\"btn btn-default disabled\" href=\"/{controller}?page=0\">",
                $"<a class=\"btn btn-default \" href=\"/{controller}?page=2\">",
                $"<th><a href=\"/{controller}/Edit/",
                $"\">Edit</a> | <a href=\"/{controller}/Details/",
                $"\">Details</a> | <a href=\"/{controller}/Delete/",
                ">Delete</a></th>"
            };
            strings.AddRange(specificStringsToTestInIndexView());
            await testWhenLoggedIn(a,strings.ToArray());
        }
        protected abstract List<string> specificStringsToTestInIndexView();
        [TestMethod] public async Task CreateTest() {
            await createTest(x => x.Create(), controller, detailsViewCaption);
        }
        [TestMethod] public async Task DeleteTest() {
            var id = createDbRecord();
            await deleteTest(id);
        }
        private async Task deleteTest(string id) {
            var a = GetUrl.ForControllerAction<TController>(x => x.Delete(""));
            a = a + $"/{id}";
            await testWhenLoggedOut(a, HttpStatusCode.Unauthorized);
            var strings = new List<string> {
                "<h2>Delete</h2>",
                $"<form action=\"/{controller}/delete/{id}\" method=\"post\">",
                $"<h4>{detailsViewCaption}</h4>",
                "<input type=\"submit\" value=Delete class=\"btn btn-default\" />",
                $"<a href=\"/{controller}\">Back to List</a>"
            };
            strings.AddRange(specificStringsToTestInView);
            await testWhenLoggedIn(a, strings.ToArray());
        }
        [TestMethod] public async Task DetailsTest() {
            var id = createDbRecord();
            var a = GetUrl.ForControllerAction<TController>(x => x.Details(""));
            a = a + $"/{id}";
            await testWhenLoggedOut(a, HttpStatusCode.Unauthorized);
            var strings = new List<string> {
                "<h2>Details</h2>",
                $"<h4>{detailsViewCaption}</h4>",
                $"<a href=\"/{controller}/Edit/{id}\">Edit</a>",
                $"<a href=\"/{controller}\">Back to List</a>"
            };
            strings.AddRange(specificStringsToTestInView);
            await testWhenLoggedIn(a, strings.ToArray());
        }
        protected async Task createTest(Expression<Func<TController, object>> action,
            string controllerName,
            string header, string postAction = "create") {
            var a = GetUrl.ForControllerAction(action);
            await testWhenLoggedOut(a, HttpStatusCode.Unauthorized);
            await testWhenLoggedIn(a,
                "<h2>Create</h2>",
                $"<form action=\"/{controllerName}/{postAction}\" method=\"post\">",
                $"<h4>{header}</h4>",
                "<input type=\"submit\" value=Create class=\"btn btn-default\" />",
                $"<a href=\"/{controllerName}\">Back to List</a>"
            );

        }
        [TestMethod] public async Task DeleteConfirmedTest() {
            var id = createDbRecord();
            await deleteTest(id);
            var a = GetUrl.ForControllerAction<TController>(x => x.Delete(""));
            a = a + $"/{id}";
            TestAuthenticationHandler.IsLoggedIn = true;
            var response = await client.GetAsync(a);
            response.EnsureSuccessStatusCode();
            var d = new Dictionary<string, string> {
                {"ID", id}
            };
            var content = new FormUrlEncodedContent(d);
            TestAuthenticationHandler.IsLoggedIn = true;
            response = await client.PostAsync(a, content);
            Assert.AreEqual(HttpStatusCode.Redirect, response.StatusCode);
            await isNotInRepository(id);
        }
        protected abstract Task isNotInRepository(string id);
        [TestMethod] public async Task EditTest() {
            await editTest(x => x.Edit(""), () => actualEditAction, () =>editViewCaption, () =>specificStringsToTestInView);
        }
        protected async Task editTest(Expression<Func<TController, object>> actionMethod, Func<string> actionName, 
            Func<string> header, Func<List<string>> stringsToTestInView) {
            var id = createDbRecord();
            var a = GetUrl.ForControllerAction(actionMethod);
            a = a + $"/{id}";
            await testWhenLoggedOut(a, HttpStatusCode.Unauthorized);
            var strings = new List<string> {
                "<h2>Edit</h2>",
                $"type=\"hidden\" value=\"{id}\"",
                $"<form action=\"/{controller}/{actionName()}/{id}\" method=\"post\">",
                $"<h4>{header()}</h4>",
                "<input type=\"submit\" value=Save class=\"btn btn-default\" />",
                $"<a href=\"/{controller}\">Back to List</a>"
            };
            strings.AddRange(stringsToTestInView());
            await testWhenLoggedIn(a, strings.ToArray());
        }
        [TestMethod]
        public async Task CreateAllGivenTest() {
            await createAllGivenTest<TController>(createRandomViewModel, x => x.Create());
        }

        protected async Task createAllGivenTest<T>(Func<object> createRandom, Expression<Func<T, object>> action)
            where T : Controller, ISentryController {
            var o = createRandom();
            var a = GetUrl.ForControllerAction(action);
            TestAuthenticationHandler.IsLoggedIn = true;
            var response = await client.GetAsync(a);
            response.EnsureSuccessStatusCode();
            var d = createHttpPostContext(o);
            var content = new FormUrlEncodedContent(d);
            TestAuthenticationHandler.IsLoggedIn = true;
            response = await client.PostAsync(a, content);
            Assert.AreEqual(HttpStatusCode.Redirect, response.StatusCode);
            await validateEntityInRepository(o);
        }

        protected abstract Task validateEntityInRepository(object o);
        protected abstract IEnumerable<KeyValuePair<string, string>> createHttpPostContext(object o);
        protected abstract object createRandomViewModel();
    }
}
