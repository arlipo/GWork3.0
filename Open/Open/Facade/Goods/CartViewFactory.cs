using Open.Domain.ShoppingCart;

namespace Open.Facade.Goods
{
    public static class CartViewFactory
    {
        public static CartView Create(CartItem itm)
        {
            var o = new CartView().GoodsData = itm.Data.GoodsCart;
            return o;
        }
    }
}