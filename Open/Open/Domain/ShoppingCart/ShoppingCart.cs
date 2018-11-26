using System.Collections.Generic;
using System.Web;
using Open.Data.Goods;

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

        public void AddItem(GoodsData data)
        {
            var newItem = new CartItem(data);
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

        public void SetItemQuantity(GoodsData data, int quantity)
        {
            if (quantity == 0)
            {
                RemoveItem(data);
                return;
            }

            var updatedItem = new CartItem(data);

            foreach (var item in Items)
            {
                if (!item.Equals(updatedItem)) continue;
                item.Quantity = quantity;
                return;
            }
        }

        public void RemoveItem(GoodsData data)
        {
            var removedItem = new CartItem(data);
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