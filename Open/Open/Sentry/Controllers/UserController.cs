using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Open.Domain.Users;


namespace Open.Sentry.Controllers { 
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
