using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Open.Domain.Goods;
namespace Open.Sentry.Controllers
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