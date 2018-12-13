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
        private static readonly ShoppingCart cart = new ShoppingCart();

        [Authorize]
        public IActionResult Index()
        {
            return View(cart);
        }

        public static void Add(GoodsData db)
        {
            cart.AddItem(db);
        }

        public IActionResult PlusOne(string id)
        {
            var item = cart.GetCartItemByID(id);
            Add(item.Data);
            return RedirectToAction("Index");
        }

        public IActionResult MinusOne(string id)
        {
            var item = cart.GetCartItemByID(id);
            cart.RemoveItem(item.Data);
            removeItemIfQuantityIsNull(item);
            return RedirectToAction("Index");
        }

        public void removeItemIfQuantityIsNull(CartItem item)
        {
            if (item.Quantity == 0)
            {
                cart.Remove(item);
            }
        }

        public IActionResult Remove(string id)
        {
            var item = cart.GetCartItemByID(id);
            cart.Remove(item);
            return RedirectToAction("Index");
        }
    }
}