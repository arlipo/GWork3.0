using Open.Aids;
using Open.Facade.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace Open.Facade.Customers
{
    public class CustomerView : NamedView
    {
        private string id, code, phone, email, address;

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
        public string Email
        {
            get => getString(ref email);
            set => email = value;
        }

        [Required, RegularExpression(RegularExpressionFor.EnglishTextOnly)]
        public string Address
        {
            get => getString(ref address);
            set => address = value;
        }

        [Required, RegularExpression(RegularExpressionFor.NumericOnly)]
        public string Phone
        {
            get => getString(ref phone);
            set => phone = value;
        }
    }
}
