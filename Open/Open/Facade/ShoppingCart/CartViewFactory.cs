using Open.Domain.ShoppingCart;

namespace Open.Facade.ShoppingCart {
    public static class CartViewFactory {
        public static CartView Create(CartItem itm) {
            var data = itm.Data.GoodsData;
            var o = new CartView {
                GoodsData = data,
                Quantity = itm.Data.Quantity
            };
            return o;
        }
    }
}