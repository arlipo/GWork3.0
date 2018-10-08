using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.WebEncoders.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Facade.Party;
using Open.Sentry.Extensions;
namespace Open.Tests.Sentry.Extensions {
    [TestClass] public class HtmlExtensionTests : BaseTests {

        private IHtmlHelper<CountryView> helper;
        private StringWriter writer; 

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(HtmlExtension);
            helper = new mockHtmlHelper<CountryView>();
            writer = new StringWriter();
        }

        [TestMethod] public void EditingControlsForEnumTest() {
            var h = new mockHtmlHelper<TelecomAddressView>();
            var v = h.EditingControlsForEnum(x => x.DeviceType);
            v.WriteTo(writer, new HtmlTestEncoder());
            const string expected =
                "<div class=\"form-group\">" +
                "LabelFor DeviceType { class = control-label col-md-2 }" +
                "<div class=\"col-md-4\">" +
                "DropDownListFor DeviceType { class = form-control }" +
                "ValidationMessageFor DeviceType { class = text-danger }" +
                "</div>" +
                "</div>";
            Assert.AreEqual(expected, writer.ToString());
        }

        [TestMethod] public void EditingControlsForTest() {
            var v = helper.EditingControlsFor(x => x.Alpha2Code);
            v.WriteTo(writer, new HtmlTestEncoder());
            const string expected =
                "<div class=\"form-group\">"+
                "LabelFor Alpha2Code { class = control-label col-md-2 }"+
                "<div class=\"col-md-4\">"+
                "EditorFor Alpha2Code { htmlAttributes = { class = form-control } }"+
                "ValidationMessageFor Alpha2Code { class = text-danger }"+
                "</div>"+
                "</div>";
            Assert.AreEqual(expected, writer.ToString());
        }

        [TestMethod] public void ViewingControlsForTest() {
            var v = helper.ViewingControlsFor(x => x.Alpha2Code);
            v.WriteTo(writer, new HtmlTestEncoder());
            const string expected =
                "<div class=\"form-group\">"+
                "LabelFor Alpha2Code { class = control-label col-md-2 }"+
                "<div class=\"col-md-10\" style=\"margin-top:10px\">"+
                "DisplayFor Alpha2Code { htmlAttributes = { class = form-control } }"+
                "</div>"+
                "</div>";
            Assert.AreEqual(expected, writer.ToString());
        }

        [TestMethod] public void SortColumnHeaderForTest() {
            var s = GetRandom.String();
            var v = helper.SortColumnHeaderFor(s, x => x.Alpha2Code);
            v.WriteTo(writer, new HtmlTestEncoder());
            var expected =
                "<th>" +
                "ActionLink Index { SortOrder = " +
                s +
                " }" +
                "</th>";
            Assert.AreEqual(expected, writer.ToString());
        }

        [TestMethod] public void EditDetailDeleteForTest() {
            var v = helper.EditDetailDeleteFor(x => x.Alpha2Code);
            v.WriteTo(writer, new HtmlTestEncoder());
            const string expected =
                "<th>" +
                "ActionLink Edit { id = Alpha2Code }" +
                " | " +
                "ActionLink Details { id = Alpha2Code }" +
                " | " +
                "ActionLink Delete { id = Alpha2Code }" +
                "</th>";
            Assert.AreEqual(expected, writer.ToString());
        }

    }
}
