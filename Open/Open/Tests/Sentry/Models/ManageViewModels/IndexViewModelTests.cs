using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Sentry.Models.ManageViewModels;
namespace Open.Tests.Sentry.Models.ManageViewModels
{
    [TestClass]
    public class IndexViewModelTests : ObjectTests<IndexViewModel>
    {


        [TestMethod] public void UsernameTest() {
            isNullableReadWriteStringProperty(() => obj.Username, x => obj.Username = x);
            hasAttributes(o => o.Username);
        }

        [TestMethod] public void IsEmailConfirmedTest() {
            canReadWrite(() => obj.IsEmailConfirmed, x => obj.IsEmailConfirmed = x);
            hasAttributes(o => o.IsEmailConfirmed);
        }

        [TestMethod] public void EmailTest() {
            isNullableReadWriteStringProperty(() => obj.Email, x => obj.Email = x);
            hasAttributes(o => o.Email, typeof(RequiredAttribute), typeof(EmailAddressAttribute));
        }

        [TestMethod] public void PhoneNumberTest() {
            isNullableReadWriteStringProperty(() => obj.PhoneNumber, x => obj.PhoneNumber = x);
            hasAttributes(o => o.PhoneNumber, typeof(DisplayAttribute), typeof(PhoneAttribute));
        }

        [TestMethod] public void StatusMessageTest() {
            isNullableReadWriteStringProperty(() => obj.StatusMessage, x => obj.StatusMessage = x);
            hasAttributes(o => o.StatusMessage);
        }

        protected override IndexViewModel getRandomObject() => GetRandom.Object<IndexViewModel>();
    }
}
