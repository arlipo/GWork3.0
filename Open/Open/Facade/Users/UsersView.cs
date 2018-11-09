using System.ComponentModel.DataAnnotations;
using Open.Aids;
using Open.Facade.Common;

namespace Open.Facade.Users
{
    public class UserView : NamedView
    {
        private string id, code, phone, address, login, password;

        public string ID
        {
            get => getString(ref id);
            set => id = value;
        }

        public string Code
        {
            get => getString(ref code);
            set => code = value;
        }
        [Required, RegularExpression(RegularExpressionFor.EnglishTextOnly)]
        public string Address
        {
            get => getString(ref address);
            set => address = value;
        }
        [Required, RegularExpression(RegularExpressionFor.EnglishTextOnly)]
        public string Login
        {
            get => getString(ref login);
            set => login = value;
        }

        [Required, RegularExpression(RegularExpressionFor.EnglishTextOnly)]
        public string Password
        {
            get => getString(ref password);
            set => password = value;
        }

        [Required, RegularExpression(RegularExpressionFor.NumericOnly)]
        public string Phone
        {
            get => getString(ref phone);
            set => phone = value;
        }
    }
}
