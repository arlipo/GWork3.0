using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Sentry.Models.ManageViewModels;
namespace Open.Tests.Sentry.Models.ManageViewModels
{
    [TestClass]
    public class EnableAuthenticatorViewModelTests : ObjectTests<EnableAuthenticatorViewModel>
    {
        [TestMethod] public void CodeTest() {
            isNullableReadWriteStringProperty(() => obj.Code, x => obj.Code = x);
            hasAttributes(o => o.Code, typeof(RequiredAttribute), typeof(DisplayAttribute),
                typeof(RequiredAttribute), typeof(StringLengthAttribute));
        }

        [TestMethod] public void SharedKeyTest() {
            isNullableReadWriteStringProperty(() => obj.SharedKey, x => obj.SharedKey = x);
            hasAttributes(o => o.SharedKey, typeof(BindNeverAttribute));
        }

        [TestMethod] public void AuthenticatorUriTest() {
            isNullableReadWriteStringProperty(() => obj.AuthenticatorUri, x => obj.AuthenticatorUri = x);
            hasAttributes(o => o.AuthenticatorUri, typeof(BindNeverAttribute));
        }

        protected override EnableAuthenticatorViewModel getRandomObject() =>
            GetRandom.Object<EnableAuthenticatorViewModel>();
    }
}
