using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Open.Data.Goods;
using Open.Domain.Goods;
using Open.Domain.ShoppingCart;
namespace Open.Sentry.Controllers
{
    public class CartController : Controller
    {
        private static ShoppingCart cart = new ShoppingCart();

        [Authorize]
        public IActionResult Index()
        {
            return View(cart);
        }

        public static void Add(GoodsData db)
        {
            cart.AddItem(db);
        }
    }
}