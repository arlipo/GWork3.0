using Open.Data.Common;

namespace Open.Data.Users
{
    public class UsersData : NamedData
    {
        private string phone;
        private string address;
        private string login;
        private string password;

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

        public string Login
        {
            get => getString(ref login);
            set => login = value;
        }

        public string Password
        {
            get => getString(ref password);
            set => password = value;
        }
    }

}