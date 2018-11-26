using System.Collections.Generic;
using System.Web;

namespace Open.Domain.ShoppingCart
{
    public class ShoppingCart
    {
        public List<CartItem> Items { get; private set; }

        public static readonly ShoppingCart Instance;

        static ShoppingCart()
        {
            if (HttpContext.Current.Session["ASPNETShoppingCart"] == null)
            {
                Instance = new ShoppingCart();
                Instance.Items = new List<CartItem>();
                HttpContext.Current.Session["ASPNETShoppingCart"] = Instance;
            }
            else Instance = (ShoppingCart) HttpContext.Current.Session["ASPNETShoppingCart"];
        }

        protected ShoppingCart() { }

        public void AddItem(int productId)
        {
            CartItem newItem = new CartItem(productId);
        }
    }
}