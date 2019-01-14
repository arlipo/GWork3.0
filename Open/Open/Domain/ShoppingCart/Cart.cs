using System.Collections.Generic;
using System.Web;
using Open.Data.Goods;
using Open.Data.ShoppingCart;
namespace Open.Domain.ShoppingCart
{
    public class Cart : List<CartItem>
    {
        public void AddItem(CartData data)
        {
            var newItem = new CartItem(data);
            foreach (var item in this)
            {
                if (item.Data.ID.Equals(newItem.Data.ID)) {
                    item.Data.Quantity++;
                    return;
                }
            }
            newItem.Data.Quantity = 1;
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
        public void RemoveItem(CartData data)
        {
            var newItem = new CartItem(data);
            foreach (var item in this)
            {
                if (item.Data.ID.Equals(newItem.Data.ID))
                {
                    item.Data.Quantity--;
                    return;
                }
            }
        }

        public decimal GetSubTotal()
        {
            decimal subTotal = 0;
            foreach (var item in this) subTotal += item.Data.TotalPrice;
            return subTotal;
        }

        public CartItem GetCartItemByID(string id)
        {
            foreach (var item in this)
            {
                if (item.Data.ID.Equals(id)) return item;
            }
            return new CartItem(new CartData()); 
        }

        public void RemoveAllItems()
        {
            RemoveRange(0, Count);
        }
    }
}