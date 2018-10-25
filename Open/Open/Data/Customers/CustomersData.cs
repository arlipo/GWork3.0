using Open.Data.Common;

namespace Open.Data.Customers
{
    public class CustomersData : NamedData
    {
        private string email;
        private string phone;
        private string address;

        public string Email
        {
            get => getString(ref email);
            set => email = value;
        }

        public string Phone
        {
            get => getString(ref phone);
            set => phone = value;
        }

        public string Address
        {
            get => getString(ref address);
            set => address = value;
        }
    }
}
