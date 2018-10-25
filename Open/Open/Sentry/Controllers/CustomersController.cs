using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Open.Domain.Customers;

namespace Open.Sentry.Controllers
{
    [Authorize]
    public class CustomersController : Controller
    {
        private readonly ICustomersRepository repository;
        internal const string properties = "ID, Name, Code, Email, Phone, Address";
        public CustomersController(ICustomersRepository r)
        {
            repository = r;
        }
    }
}
