using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Open.Data.Goods;
using Open.Data.ShoppingCart;
using Open.Domain.Goods;
using Open.Domain.ShoppingCart;
using Open.Facade.Goods;
using Open.Facade.ShoppingCart;
namespace Open.Sentry.Controllers {
    public class CartController : Controller {
        private static readonly Cart cart = new Cart();

        //[Authorize]
        public IActionResult Index() {
            var l = new CartViewsList(cart);
            return View(l);
        }

        public static void Add(CartData db) {
            cart.AddItem(db);
        }

        public IActionResult CheckOut() {
            return View("Checkout");
        }

        public IActionResult PlusOne(string id) {
            var item = cart.GetCartItemByID(id);
            Add(item.Data);
            return RedirectToAction("Index");
        }

        public IActionResult MinusOne(string id) {
            var item = cart.GetCartItemByID(id);
            cart.RemoveItem(item.Data);
            removeItemIfQuantityIsNull(item);
            return RedirectToAction("Index");
        }

        public void removeItemIfQuantityIsNull(CartItem item) {
            if (item.Data.Quantity == 0) { cart.Remove(item); }
        }

        public IActionResult Remove(string id) {
            var item = cart.GetCartItemByID(id);
            cart.Remove(item);
            return RedirectToAction("Index");
        }
    }
}