﻿using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Open.Sentry.Data;
using Open.Sentry.Models;
using Open.Sentry.Models.AccountViewModels;

namespace Open.Sentry.Controllers
{
    public class CreditsController : Controller
    {
        private readonly ApplicationDbContext _dataContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public CreditsController(ApplicationDbContext dataContext, UserManager<ApplicationUser> userManager)
        {
            _dataContext = dataContext;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public async Task<IActionResult> ShowUser(CreditsViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user is null) return View("Index");
            model.Credits = user.Credits;
            return View(model);
        }

        public static string UserBalance(ApplicationUser user)
        {
            var balance = user.Credits.ToString();
            return balance;
        }

        public async Task<IActionResult> SetAmount(CreditsViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            user.Credits = model.Credits;
            await _userManager.UpdateAsync(user);
            return View("ShowUser", model);
        }
    }
}