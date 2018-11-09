using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Open.Domain.Users;


namespace Open.Sentry.Controllers
{
    public class UserController : Controller
    {
        [Authorize]
        public class UsersController : Controller
        {
            private readonly IUsersRepository repository;
            internal const string properties = "ID, Name, Code, Phone, Address";

            public UsersController(IUsersRepository r)
            {
                repository = r;
            }
        }
    }
}
