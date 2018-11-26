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
                Instance = new ShoppingCart {Items = new List<CartItem>()};
                HttpContext.Current.Session["ASPNETShoppingCart"] = Instance;
            }
            else Instance = (ShoppingCart) HttpContext.Current.Session["ASPNETShoppingCart"];
        }

        protected ShoppingCart() { }

        public void AddItem(int productId)
        {
            var newItem = new CartItem(productId);
            if (Items.Contains(newItem))
            {
                foreach (var item in Items)
                {
                    if (!item.Equals(newItem)) continue;
                    item.Quantity++;
                    return;
                }
            }
            else
            {
                newItem.Quantity = 1;
                Items.Add(newItem);
            }
        }

        public void SetItemQuantity(int productId, int quantity)
        {
            if (quantity == 0)
            {
                RemoveItem(productId);
                return;
            }

            var updatedItem = new CartItem(productId);

            foreach (var item in Items)
            {
                if (!item.Equals(updatedItem)) continue;
                item.Quantity = quantity;
                return;
            }
        }

        public void RemoveItem(int productId)
        {
            var removedItem = new CartItem(productId);
            Items.Remove(removedItem);
        }

        public decimal GetSubTotal()
        {
            decimal subTotal = 0;
            foreach (var item in Items) subTotal += item.TotalPrice;
            return subTotal;
        }
    }
}