using Open.Domain.ShoppingCart;

namespace Open.Facade.Goods
{
    public static class CartViewFactory
    {
        public static CartView Create(CartItem itm)
        {
            var db = itm.Data.GoodsData;
            var o = new CartView
            {
                GoodsData = db,
                Quantity = itm.Data.Quantity
            };
            return o;
        }
    }
}