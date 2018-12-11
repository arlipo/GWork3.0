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
            foreach (var item in this)
            {
                if (item.Data.ID.Equals(newItem.Data.ID)) {
                    item.Quantity++;
                    return;
                }
            }
            newItem.Quantity = 1;
            Add(newItem);
        }
        /* -------------------NOT-USED-YET-----------------------
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
        */
        public void RemoveItem(GoodsData data)
        {
            var item = GetCartItemByID(data.ID);
            Remove(item);
        }

        public decimal GetSubTotal()
        {
            decimal subTotal = 0;
            foreach (var item in this) subTotal += item.TotalPrice;
            return subTotal;
        }

        public CartItem GetCartItemByID(string id)
        {
            foreach (var item in this)
            {
                if (item.Data.ID.Equals(id)) return item;
            }
            return new CartItem(new GoodsData()); 
        }
    }
}