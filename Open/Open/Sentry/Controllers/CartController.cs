using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Open.Data.ShoppingCart;
using Open.Domain.ShoppingCart;
using Open.Facade.ShoppingCart;
using Open.Sentry.Models;

namespace Open.Sentry.Controllers {
    public class CartController : Controller {
        private static readonly Cart cart = new Cart();
        private readonly UserManager<ApplicationUser> um;

        public CartController(UserManager<ApplicationUser> um) { this.um = um; }

        [Authorize]
        public IActionResult Index() {
            return View(new CartViewsList(cart));
        }

        public static void Add(CartData db) {
            cart.AddItem(db);
        }

        [Authorize]
        public IActionResult Checkout() {
            return View(new CartViewsList(cart));
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
        
        [Authorize]
        public async Task<IActionResult> Buy()
        {
            var user = await um.GetUserAsync(User);
            var cost = cart.GetSubTotal();
            var isCreditsRemoved = user.RemoveCredits(cost);
            if (isCreditsRemoved)
            {
                await um.UpdateAsync(user);
                return RedirectToAction("Index", "Home");
            }
            return View("Checkout");
        }
    }
}