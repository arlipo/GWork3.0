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
            var ind = cart.IndexOf(item);
            cart[ind].Quantity++;
            return RedirectToAction("Index");
        }

        public IActionResult MinusOne(string id)
        {
            var item = cart.GetCartItemByID(id);
            var ind = cart.IndexOf(item);
            cart[ind].Quantity--;
            removeItemIfQuantityIsNull(ind);
            return RedirectToAction("Index");
        }

        public void removeItemIfQuantityIsNull(int ind)
        {
            var item = cart[ind];
            if (item.Quantity == 0)
            {
                cart.RemoveItem(item.Data);
            }
        }
    }
}