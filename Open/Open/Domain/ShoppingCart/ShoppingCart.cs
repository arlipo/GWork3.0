using System.Collections.Generic;
using System.Web;
using Open.Data.Goods;

namespace Open.Domain.ShoppingCart
{
    public class ShoppingCart : List<CartItem>
    {
        public void AddItem(GoodsData data)
        {
            var newItem = new CartItem(data);
            if (Contains(newItem))
            {
                foreach (var item in this)
                {
                    if (!item.Equals(newItem)) continue;
                    item.Quantity++;
                    return;
                }
            }
            else
            {
                newItem.Quantity = 1;
                Add(newItem);
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

            foreach (var item in this)
            {
                if (!item.Equals(updatedItem)) continue;
                item.Quantity = quantity;
                return;
            }
        }

        public void RemoveItem(GoodsData data)
        {
            var removedItem = new CartItem(data);
            Remove(removedItem);
        }

        public decimal GetSubTotal()
        {
            decimal subTotal = 0;
            foreach (var item in this) subTotal += item.TotalPrice;
            return subTotal;
        }
    }
}