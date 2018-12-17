using System.Collections.Generic;
using Open.Domain.ShoppingCart;

namespace Open.Facade.Goods
{
    public class CartViewsList : List<CartView>
    {
        private ShoppingCart cart;

        public CartViewsList(ShoppingCart cart)
        {
            if (cart is null) return;
            this.cart = cart;
            foreach (var o in cart)
            {
                Add(CartViewFactory.Create(o));
            }
        }

        public decimal SubTotal()
        {
            return cart.GetSubTotal();
        }
    }
}