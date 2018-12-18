using System.Collections.Generic;
using Open.Domain.ShoppingCart;

namespace Open.Facade.ShoppingCart {
    public class CartViewsList : List<CartView> {
        private Cart cart;

        public CartViewsList(Cart cart) {
            if (cart is null) return;
            this.cart = cart;
            foreach (var o in cart) { Add(CartViewFactory.Create(o)); }
        }

        public decimal SubTotal() {
            return cart.GetSubTotal();
        }
    }
}