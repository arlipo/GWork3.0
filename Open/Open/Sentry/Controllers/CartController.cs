using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Open.Domain.Goods;
using Open.Domain.ShoppingCart;
using Open.Sentry.Controllers;

namespace Sentry.Controllers
{
    public class CartController : GoodsController
    {
        [Authorize]
        public IActionResult CartIndex()
        {
            return View(cart);
        }


        public CartController(IGoodsRepository r) : base(r) {}
    }
}