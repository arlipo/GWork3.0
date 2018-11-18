using Open.Data.Common;
using Open.Data.Goods;

namespace Open.Data.ShoppingCartItem
{
    public class ShoppingCartItem : NamedData
    {
        public int ShoppingCartItemId { get; set; }
        public GoodsData Goods { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
